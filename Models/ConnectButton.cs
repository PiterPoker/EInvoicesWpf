using EInvoicesWpf.Models.Helper;
using EInvoicesWpf.Models.StepsViewModel;
using EInvoicesWPF.DAL.Entities;
using EInvoicesWPF.DAL.Interfaces;
using EInvoicesWPF.DAL.Repositories;
using EInvoicesWPF.Services.DTO;
using EInvoicesWPF.Services.ServiceModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;

namespace EInvoicesWpf.Models
{
    public class ConnectButton : Steps4ViewModel, INotifyPropertyChanged
    {
        public ConnectButton()
        {
            var autoStartingActionCountdownStart = DateTime.Now;
            var demoRestartCountdownComplete = DateTime.Now;
            //just some demo code for the SAVE button
            SaveCommand = new AnotherCommandImplementation(_ =>
            {
                if (IsSaveComplete == true)
                {
                    IsSaveComplete = false;
                    KirmashConnectBdf.error_3torg = true;
                    KirmashConnectBdf.error_60chet = true;
                    KirmashConnectBdf.error_esf = true;
                    return;
                }
                if (SaveProgress != 0) return;

                var started = DateTime.Now;
                IsSaving = true;

                SettingService settingService = new SettingService();

                SettingDTO setting = new SettingDTO(
                          Properties.Settings.Default.path_3torg,
                          Properties.Settings.Default.path_60chet,
                          Properties.Settings.Default.path_esf);
                settingService.LoadAsync();

                new DispatcherTimer(
                    TimeSpan.FromMilliseconds(50),
                    DispatcherPriority.Normal,
                    new EventHandler((o, e) =>
                    {                     

                        var totalDuration = started.AddSeconds(25).Ticks - started.Ticks;
                        var currentProgress = DateTime.Now.Ticks - started.Ticks;
                        var currentProgressPercent = 100.0 / totalDuration * currentProgress;

                        SaveProgress = currentProgressPercent;

                        if (SaveProgress >= 100)
                        {
                            if(KirmashConnectBdf.error_3torg == false &&
                        KirmashConnectBdf.error_60chet == false &&
                        KirmashConnectBdf.error_esf == false) {
                                IsSaveComplete = true;
                                IsSaving = false;
                                SaveProgress = 0;
                            }                            
                            ((DispatcherTimer)o).Stop();
                            IsSaving = false;
                            SaveProgress = 0;
                        }
                    }), Dispatcher.CurrentDispatcher);
            });
             
        }

        #region floating Save button demo

        public ICommand SaveCommand { get; }

        private bool _isSaving;
        public bool IsSaving
        {
            get { return _isSaving; }
            private set { this.MutateVerbose(ref _isSaving, value, RaisePropertyChanged()); }
        }

        private bool _isSaveComplete;
        public bool IsSaveComplete
        {
            get { return _isSaveComplete; }
            private set { this.MutateVerbose(ref _isSaveComplete, value, RaisePropertyChanged()); }
        }

        private double _saveProgress;
        public double SaveProgress
        {
            get { return _saveProgress; }
            private set { this.MutateVerbose(ref _saveProgress, value, RaisePropertyChanged()); }
        }
        #endregion

        public new event PropertyChangedEventHandler PropertyChanged;

        private Action<PropertyChangedEventArgs> RaisePropertyChanged()
        {
            return args => PropertyChanged?.Invoke(this, args);
        }
    }
}
