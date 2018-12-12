using EInvoicesWPF.Services.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EInvoicesWpf.Models
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel(StatusBarDTO _statusBarDTO)
        {
            this.statusBarDTO = _statusBarDTO;
            this.StatusBarDTO.statusProcess = Properties.Settings.Default.run_app.ToString();
        }

        private StatusBarDTO statusBarDTO;

        public StatusBarDTO StatusBarDTO
        {
            get { return statusBarDTO; }
            set
            {
                statusBarDTO = value;
                OnPropertyChanged("StatusBarDTO");
            }
        }

        StatusBarDTO modelStatusBarDTO = new StatusBarDTO();

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
