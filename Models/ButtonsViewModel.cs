using EInvoicesWpf.Models.DialogService;
using EInvoicesWpf.Models.FileService;
using EInvoicesWpf.Models.Helper;
using EInvoicesWPF.Services.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EInvoicesWpf.Models
{
    public class ButtonsViewModel : INotifyPropertyChanged
    {
        SettingDTO modelSettingDTO = new SettingDTO(
                            Properties.Settings.Default.path_3torg,
                            Properties.Settings.Default.path_60chet,
                            Properties.Settings.Default.path_esf);
        public ButtonsViewModel(IDialogService _dialogService,IFileService _fileService, SettingDTO _settingDTO)
        {
            this.dialogService = _dialogService;
            this.fileService = _fileService;
            this.settingDTO = _settingDTO;            
        }
        StatusBarDTO modelStatusBarDTO = new StatusBarDTO();
        MainWindowViewModel main = new MainWindowViewModel(new StatusBarDTO());

        // команда добавления нового объекта
        private IDialogService dialogService;
        private IFileService fileService;
        private SettingDTO settingDTO;

        private RelayCommand path_3torgCommand;
        private RelayCommand path_60chetCommand;
        private RelayCommand path_esfCommand;

        public RelayCommand Path_3torgCommand
        {
            get
            {
                return path_3torgCommand ??
                  (path_3torgCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SavePathDialog(1) == true)
                          {
                              SettingDTO.path_3torg = dialogService.FilePath;
                              SettingDTO = modelSettingDTO;
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public RelayCommand Path_60chetCommand
        {
            get
            {
                return path_60chetCommand ??
                  (path_60chetCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SavePathDialog(2) == true)
                          {
                              SettingDTO.path_60chet = dialogService.FilePath;
                              SettingDTO = modelSettingDTO;
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public RelayCommand Path_esfCommand
        {
            get
            {
                return path_esfCommand ??
                  (path_esfCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SavePathDialog(3) == true)
                          {
                              SettingDTO.path_esf = dialogService.FilePath;
                              SettingDTO = modelSettingDTO;
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }

        public SettingDTO SettingDTO
        {
            get { return settingDTO = modelSettingDTO; }
            set
            {
                settingDTO = value;
                OnPropertyChanged("SettingDTO");
            }
        }

        public IDialogService GetFileName
        {
            get { return dialogService; }
            set
            {
                dialogService = value;
                OnPropertyChanged("GetFileName");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
