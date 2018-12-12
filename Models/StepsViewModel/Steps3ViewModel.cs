using EInvoicesWpf.Models.DialogService;
using EInvoicesWpf.Models.Helper;
using EInvoicesWPF.Services.DTO;
using EInvoicesWPF.Services.Interface;
using EInvoicesWPF.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EInvoicesWpf.Models.StepsViewModel
{
    public class Steps3ViewModel : Steps2ViewModel
    {
        CalendarDTO calendar = new CalendarDTO();
        IDialogService dialog = new DefaultDialogService();
        IThirdPartySoftwareService softwareService = new ThirdPartySoftwareService();
        CheckDataService checkData;

        public Steps3ViewModel()
        {
            VisibleCheckFalse_Esf = "Hidden";
            VisibleCheckTrue_Esf = "Hidden";
            VisibleCheckFalse_Sub = "Hidden";
            VisibleCheckTrue_Sub = "Hidden";
            BlockButton = false;

            CheckEsfCommand = new AnotherCommandImplementation(async _ =>
            {
                if (VisibleCheckTrue_Esf == "Visible" || VisibleCheckFalse_Esf == "Visible")
                {
                    VisibleCheckTrue_Esf = "Hidden";
                    VisibleCheckFalse_Esf = "Hidden";
                }
                WorkerState = true;
                await Task.Run(() => { checkData = new CheckDataService(); checkData.CheckAllEInvoices_Step1(); checkData.CheckAllEInvoices_Step2(); });
                WorkerState = !true;
                VisibleCheckTrue_Esf = "Visible";
            });

            SubscribeEsfCommand = new AnotherCommandImplementation(async _ =>
            {
                if (VisibleCheckTrue_Sub == "Visible" || VisibleCheckFalse_Sub == "Visible")
                {
                    VisibleCheckTrue_Sub = "Hidden";
                    VisibleCheckFalse_Sub = "Hidden";
                }
                WorkerState = true;
                await Task.Run(() => { checkData = new CheckDataService(); checkData.MoveEInvoiceFiles(); });
                if (softwareService.ProcessRun(Properties.Settings.Default.path_bat_sing) == true)
                {
                    dialog.ShowMessage("Файл \"signAndUploadRecvDir.bat\" не найден!");
                    VisibleCheckFalse_Sub = "Visible";
                }
                else
                {
                    await Task.Run(() => { checkData.MuveToArhive(); });
                    VisibleCheckTrue_Sub = "Visible";
                }
                WorkerState = !true;
                BlockButton = true;
            });
        }

        public string VisibleCheckTrue_Sub
        {
            get { return _visibleCheckTrue; }
            set
            {
                if (_visibleCheckTrue == value) return;
                _visibleCheckTrue = value;
                OnPropertyChanged();
            }
        }

        public string VisibleCheckFalse_Sub
        {
            get { return _visibleCheckFalse; }
            set
            {
                if (_visibleCheckFalse == value) return;
                _visibleCheckFalse = value;
                OnPropertyChanged();
            }
        }

        public ICommand CheckEsfCommand { get; }
        public ICommand SubscribeEsfCommand { get; }
        
        private string _visibleCheckFalse;
        private string _visibleCheckTrue;
    }
}
