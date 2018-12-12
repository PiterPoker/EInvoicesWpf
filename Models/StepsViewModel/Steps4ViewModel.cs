using EInvoicesWpf.Models.DialogService;
using EInvoicesWpf.Models.Helper;
using EInvoicesWPF.DAL.Entities;
using EInvoicesWPF.Services.DTO;
using EInvoicesWPF.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EInvoicesWpf.Models.StepsViewModel
{
    public class Steps4ViewModel : INotifyPropertyChanged
    {
        CalendarDTO calendar = new CalendarDTO();
        ReleaseReportService release = new ReleaseReportService();
        IDialogService dialogService = new DefaultDialogService();
        private EInvocesXML eInvocesXML = new EInvocesXML();
        private IList<EInvocesXML> rezInvocesXML;
        private IList<EInvocesXML> _invocesXML;

        private string _dateLable;
        public Steps4ViewModel()
        {
            _dateLable = "C " + calendar.BeginDate.Date.ToString("dd.MM.yyyy") + " по " + calendar.EndDate.Date.ToString("dd.MM.yyyy") + " г.";
            WorkerState = true;
            rezInvocesXML = _invocesXML = release.eInvoces();
            WorkerState = !true;
            //Доделать проверку, если счетфактура неимеет ошибки обнулить сообщение обошибке. Вывести на экран имяпоставщика.
            ReportCommand = new AnotherCommandImplementation(async _ => {
                WorkerState = true;
                if (dialogService.SavePdfDialog())
                await Task.Run(() => { release.CreateReport(dialogService.FilePath); });
                WorkerState = !true;
            });
        }

        public bool WorkerState
        {
            get { return _workerState; }
            set
            {
                _workerState = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("WorkerState"));
            }
        }

        public bool Error
        {
            get { return eInvocesXML.Error; }
            set
            {
                eInvocesXML.Error = value;
                OnPropertyChanged();
                GetResults(eInvocesXML);
            }
        }

        public string Search
        {
            get { return eInvocesXML.Name; }
            set {
                eInvocesXML.Name = value;
                OnPropertyChanged();
                GetResults(eInvocesXML); }
        }

        private readonly ObservableCollection<EInvocesXML> _results = new ObservableCollection<EInvocesXML>();
        private bool _workerState;

        public ObservableCollection<EInvocesXML> Results { get { return _results; } }

        private async void GetResults(EInvocesXML item)
        {
            _results.Clear();
            WorkerState = true;
            await Task.Run(() => { InvocesXML = release.eInvocesResult(item); });
            WorkerState = !true;
        }

        public IList<EInvocesXML> InvocesXML
        {
            get { return _invocesXML; }
            set
            {
                _invocesXML = value;
                OnPropertyChanged("InvocesXML");
            }
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

        public ICommand ReportCommand { get; }

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
