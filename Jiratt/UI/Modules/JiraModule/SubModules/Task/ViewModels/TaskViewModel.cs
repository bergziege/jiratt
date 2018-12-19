using System;
using System.Windows;
using Atlassian.Jira;
using Jiratt.Services.Events;
using Jiratt.Services.Services;
using Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewCommands;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewModels {
    public class TaskViewModel : BindableBase, ITaskViewModel, INavigationAware {
        private readonly IEventAggregator _eventAggregator;
        private readonly ITimeSpanService _timeSpanService;
        private DelegateCommand _discardTimeCommand;
        private Issue _issue;
        private DelegateCommand _saveTimeCommand;
        private DelegateCommand _startTimeCommand;
        private DelegateCommand _stopTimeCommand;
        private TimeSpan _timeNotLogged;
        protected internal SubscriptionToken _timerTickSubscription;

        public TaskViewModel(IEventAggregator eventAggregator, ITimeSpanService timeSpanService) {
            _eventAggregator = eventAggregator;
            _timeSpanService = timeSpanService;
        }

        /// <summary>
        /// </summary>
        public DelegateCommand DiscardTimeCommand {
            get {
                if (_discardTimeCommand == null)
                    _discardTimeCommand = new DelegateCommand(DiscardTime);

                return _discardTimeCommand;
            }
        }

        public Issue Issue {
            get { return _issue; }
            private set { SetProperty(ref _issue, value); }
        }

        public DelegateCommand SaveTimeCommand {
            get {
                if (_saveTimeCommand == null)
                    _saveTimeCommand = new DelegateCommand(SaveTime);

                return _saveTimeCommand;
            }
        }

        /// <summary>
        /// </summary>
        public DelegateCommand StartTimeCommand {
            get {
                if (_startTimeCommand == null)
                    _startTimeCommand = new DelegateCommand(StartTime);

                return _startTimeCommand;
            }
        }

        /// <summary>
        /// </summary>
        public DelegateCommand StopTimeCommand {
            get {
                if (_stopTimeCommand == null)
                    _stopTimeCommand = new DelegateCommand(StopTime);

                return _stopTimeCommand;
            }
        }

        public TimeSpan TimeNotLogged {
            get { return _timeNotLogged; }
            private set { SetProperty(ref _timeNotLogged, value); }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) {
        }

        public void OnNavigatedTo(NavigationContext navigationContext) {
            if (navigationContext.Parameters.ContainsKey(ShowTaskDetailsParameters.PARAM_KEY)) {
                ShowTaskDetailsParameters navParams = (ShowTaskDetailsParameters)navigationContext.Parameters[ShowTaskDetailsParameters.PARAM_KEY];
                Initialize(navParams.Issue);
            } else {
                Initialize(null);
            }
        }

        private void DiscardTime() {
            TimeNotLogged = new TimeSpan();
        }

        private void Initialize(Issue issue) {
            Issue = issue;
            TimeNotLogged = new TimeSpan();
        }

        private void OnTimerTick(TimerTickEvent obj) {
            Application.Current.Dispatcher.Invoke(() => TimeNotLogged = TimeNotLogged.Add(obj.TimeElapsedSinceLastTick));
        }

        private void SaveTime() {
            Issue.AddWorklogAsync(_timeSpanService.GetJiraFormattedTimeSpanValue(TimeNotLogged));
            Issue.SaveChanges();
            DiscardTime();
        }

        private void StartTime() {
            if (_timerTickSubscription == null) {
                _timerTickSubscription = _eventAggregator.GetEvent<PubSubEvent<TimerTickEvent>>().Subscribe(OnTimerTick);
            }
        }

        private void StopTime() {
            if (_timerTickSubscription != null) {
                _eventAggregator.GetEvent<PubSubEvent<TimerTickEvent>>().Unsubscribe(_timerTickSubscription);
                _timerTickSubscription.Dispose();
                _timerTickSubscription = null;
            }
        }
    }
}