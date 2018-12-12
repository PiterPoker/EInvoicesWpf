using EInvoicesWpf.Models.DialogService;
using EInvoicesWpf.Models.Helper;
using EInvoicesWPF.Services.DTO;
using EInvoicesWPF.Services.Helper;
using EInvoicesWPF.Services.Interface;
using EInvoicesWPF.Services.ServiceModels;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EInvoicesWpf.Models.StepsViewModel
{
    public class Steps2ViewModel : INotifyPropertyChanged
    {
        CalendarDTO calendar = new CalendarDTO();
        IDialogService dialog = new DefaultDialogService();
        ErrorDTO errorDTO = new ErrorDTO();
        IThirdPartySoftwareService softwareService = new ThirdPartySoftwareService();
        DataXmlService settingService;

        private string _dateLable;
        private string _visibleCheckTrue;
        private string _visibleCheckFalse;

        public Steps2ViewModel() {
            _dateLable = "C "+calendar.BeginDate.Date.ToString("dd.MM.yyyy") +" по " + calendar.EndDate.Date.ToString("dd.MM.yyyy") +" г.";

            EsfProgress = true;
            SosProgress = true;
            VisibleCheckFalse_Esf = "Hidden";
            VisibleCheckTrue_Esf = "Hidden";
            VisibleCheckFalse_SOS = "Hidden";
            VisibleCheckTrue_SOS = "Hidden";

            DownloadEsfCommand = new AnotherCommandImplementation(async _ =>
            {
                if (EsfProgress == false || VisibleCheckTrue_Esf == "Visible" || VisibleCheckFalse_Esf == "Visible")
                {
                    VisibleCheckTrue_Esf = "Hidden";
                    VisibleCheckFalse_Esf = "Hidden";
                    EsfProgress = true;
                    errorDTO.Error = false;
                }
                EsfProgress = softwareService.ProcessRun(Properties.Settings.Default.path_bat_esf);

                if (EsfProgress == true)
                {
                    dialog.ShowMessage("Файл \"receive2Dir.bat\" не найден!");
                    VisibleCheckFalse_Esf = "Visible";
                }
                else
                {
                    WorkerState = true;
                    await Task.Run(() => { settingService = new DataXmlService(); settingService.LoadDataXml(); });
                    WorkerState = !true;
                    if (errorDTO.Error == true)
                    {
                        VisibleCheckFalse_Esf = "Visible";
                    }
                    else
                    {
                        VisibleCheckTrue_Esf = "Visible";
                    }
                }
            });

            UpdateSOSCommand = new AnotherCommandImplementation(_ =>
            {
                if (SosProgress == false || VisibleCheckTrue_SOS == "Visible" || VisibleCheckFalse_SOS == "Visible")
                {
                    VisibleCheckTrue_SOS = "Hidden";
                    VisibleCheckFalse_SOS = "Hidden";
                    SosProgress = true;
                }
                //если false, при обновление СОС ошибок нет.
                SosProgress = softwareService.ProcessRun(Properties.Settings.Default.path_bat_sos);
                if (SosProgress == true)
                {
                    dialog.ShowMessage("Файл \"receive2Dir.bat\" не найден!");
                    VisibleCheckFalse_SOS = "Visible";
                }
                else { VisibleCheckTrue_SOS = "Visible"; }
                
            });
        }
        
        public string DateLable
        {
            get { return _dateLable; }
            set
            {
                if (_dateLable == value) return;
                _dateLable = value;
                OnPropertyChanged();
            }
        }

        public string VisibleCheckTrue_SOS
        {
            get { return _visibleCheckTrue; }
            set
            {
                if (_visibleCheckTrue == value) return;
                _visibleCheckTrue = value;
                OnPropertyChanged();
            }
        }

        public string VisibleCheckFalse_SOS
        {
            get { return _visibleCheckFalse; }
            set
            {
                if (_visibleCheckFalse == value) return;
                _visibleCheckFalse = value;
                OnPropertyChanged();
            }
        }

        public string VisibleCheckTrue_Esf
        {
            get { return _visibleCheckTrue; }
            set
            {
                if (_visibleCheckTrue == value) return;
                _visibleCheckTrue = value;
                OnPropertyChanged();
            }
        }

        public string VisibleCheckFalse_Esf
        {
            get { return _visibleCheckFalse; }
            set
            {
                if (_visibleCheckFalse == value) return;
                _visibleCheckFalse = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateSOSCommand { get; }
        public ICommand DownloadEsfCommand { get; }

        private bool _workerState;

        public bool WorkerState
        {
            get { return _workerState; }
            set
            {
                _workerState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WorkerState"));
            }
        }

        private bool _saveProgress;
        private bool _blockButton;

        public bool EsfProgress
        {
            get { return _saveProgress; }
            private set { this.MutateVerbose(ref _saveProgress, value, RaisePropertyChanged()); }
        }

        public bool SosProgress
        {
            get { return _saveProgress; }
            private set { this.MutateVerbose(ref _saveProgress, value, RaisePropertyChanged()); }
        }

        public bool BlockButton
        {
            get { return _blockButton; }
            set { this.MutateVerbose(ref _blockButton, value, RaisePropertyChanged()); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
