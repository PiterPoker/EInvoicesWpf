using EInvoicesWpf.Models.Helper;
using EInvoicesWPF.Services.DTO;
using EInvoicesWPF.Services.ServiceModels;
using EInvoicesWpf.Models.DialogService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EInvoicesWpf.Models
{
    public class CalendarViewModel : INotifyPropertyChanged
    {
        CalendarDTO calendar = new CalendarDTO();
        DateTimeService timeService;
        IDialogService service = new DefaultDialogService();
        private DateTime _date;
        private IList<DateTime> _dateTimeList;

        public CalendarViewModel()
        {
            
            DateTimeList = _dateTimeList; 
            Date = DateTime.Now;

            FirstAndLastComand = new AnotherCommandImplementation(_ => FirstAndLasDate());
        }

        public async void FirstAndLasDate()
        {
            if (FirstAndLastcheck == true)
            {
                FirstAndLastcheck = false;
            }

            timeService = new DateTimeService();
            FirstAndLastcheck = await Task.Run(() => timeService.LastDate(calendar.DateList));
            if (FirstAndLastcheck == true)
                FirstAndLastcheck = await Task.Run(() => timeService.WritingDateTimeFile());
            else { service.ShowMessage("Ошибка при записи даты."); }
        }

        public DateTime Date
        {
            get { return calendar.BeginDate = _date; }
            set
            {
                _date = value;
                OnPropertyChanged();
            }
        }

        public IList<DateTime> DateTimeList
        {
            get { return calendar.DateList = _dateTimeList; }
            set
            {
                calendar.DateList =_dateTimeList = value;
                OnPropertyChanged();
            }
        }
        public ICommand FirstAndLastComand { get; }

        private bool _firstandlastCheck;
        public bool FirstAndLastcheck
        {
            get { return _firstandlastCheck; }
            private set { this.MutateVerbose(ref _firstandlastCheck, value, RaisePropertyChanged()); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }

        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
