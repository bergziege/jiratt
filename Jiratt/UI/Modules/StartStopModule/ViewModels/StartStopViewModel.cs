using System.Threading.Tasks;
using System.Windows;
using Jiratt.Services.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.StartStopModule.ViewModels {
    public class StartStopViewModel : BindableBase, IStartStopViewModel {
        private readonly IEventAggregator _eventAggregator;
        private bool _isTimerRunning;
        private DelegateCommand _startStopCommand;

        public StartStopViewModel(IEventAggregator eventAggregator) {
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<PubSubEvent<TimerStartedEvent>>().Subscribe(OnTimerStarted);
            _eventAggregator.GetEvent<PubSubEvent<TimerStoppedEvent>>().Subscribe(OnTimerStopped);
        }

        public DelegateCommand StartStopCommand {
            get {
                if (_startStopCommand == null) {
                    _startStopCommand = new DelegateCommand(StartStop, CanStartStop);
                }

                return _startStopCommand;
            }
        }

        private bool CanStartStop() {
            return true;
        }

        private void OnTimerStarted(TimerStartedEvent obj) {
            Application.Current.Dispatcher.Invoke(() => _isTimerRunning = true);
        }

        private void OnTimerStopped(TimerStoppedEvent obj) {
            Application.Current.Dispatcher.Invoke(() => _isTimerRunning = false);
        }

        private void StartStop() {
            if (_isTimerRunning) {
                Task.Factory.StartNew(() => _eventAggregator.GetEvent<PubSubEvent<StopTimerEvent>>().Publish(new StopTimerEvent()));
            } else {
                Task.Factory.StartNew(() => _eventAggregator.GetEvent<PubSubEvent<StartTimerEvent>>().Publish(new StartTimerEvent()));
            }
        }
    }
}