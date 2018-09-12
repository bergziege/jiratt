using System;
using System.Collections.Generic;
using System.Windows.Threading;

using Atlassian.Jira;

using Prism.Commands;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.TimeTracking.ViewModels {
    public class TimeTrackingViewModel : BindableBase, ITimeTrackingViewModel {
        private readonly DispatcherTimer _dispatcherTimer;
        private string _estimated;
        private Issue _issue;
        private DelegateCommand _logTimeCommand;
        private string _logged;
        private string _loggedIncludeNotLogged;
        private string _notLoggedTime;
        private int _notLoggedTimeInSeconds;
        private double _percentEstimated;
        private double _percentLogged;
        private double _percentLoggedIncludeNotLogged;
        private DelegateCommand _resetCommand;
        private DelegateCommand _startStopCommand;
        private IssueTimeTrackingData _timeTrackingData;

        public TimeTrackingViewModel() {
            _dispatcherTimer = new DispatcherTimer();
            _dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            _dispatcherTimer.Tick += DispatcherTimerTick;
        }

        public string Estimated {
            get { return _estimated; }
            private set {
                _estimated = value;
                RaisePropertyChanged(nameof(Estimated));
            }
        }

        public DelegateCommand LogTimeCommand {
            get {
                if (_logTimeCommand == null) {
                    _logTimeCommand = new DelegateCommand(LogTime, CanLogTime);
                }

                return _logTimeCommand;
            }
        }

        public string Logged {
            get { return _logged; }
            private set {
                _logged = value;
                RaisePropertyChanged(nameof(Logged));
            }
        }
        public string LoggedIncludeNotLogged {
            get { return _loggedIncludeNotLogged; }
            private set {
                _loggedIncludeNotLogged = value;
                RaisePropertyChanged(nameof(LoggedIncludeNotLogged));
            }
        }
        public string NotLoggedTime {
            get { return _notLoggedTime; }
            private set {
                _notLoggedTime = value;
                RaisePropertyChanged(nameof(NotLoggedTime));
            }
        }

        public double PercentEstimated {
            get { return _percentEstimated; }
            private set {
                _percentEstimated = value;
                RaisePropertyChanged(nameof(PercentEstimated));
            }
        }

        public double PercentLogged {
            get { return _percentLogged; }
            private set {
                _percentLogged = value;
                RaisePropertyChanged(nameof(PercentLogged));
            }
        }

        public double PercentLoggedIncludeNotLogged {
            get { return _percentLoggedIncludeNotLogged; }
            private set {
                _percentLoggedIncludeNotLogged = value;
                RaisePropertyChanged(nameof(PercentLoggedIncludeNotLogged));
            }
        }
        public DelegateCommand ResetCommand {
            get {
                if (_resetCommand == null) {
                    _resetCommand = new DelegateCommand(Reset);
                }

                return _resetCommand;
            }
        }

        public DelegateCommand StartStopCommand {
            get {
                if (_startStopCommand == null) {
                    _startStopCommand = new DelegateCommand(StartStop, CanStartStop);
                }

                return _startStopCommand;
            }
        }

        public void LoadData(Issue issue) {
            _issue = issue;
            _timeTrackingData = _issue.GetTimeTrackingDataAsync().GetAwaiter().GetResult();
            UpdateTimePercents();
        }

        private bool CanLogTime() {
            /* In Jira können nur Zeiten >= 60 Sekunden geloggt werden. */
            return _notLoggedTimeInSeconds > 59;
        }

        private bool CanStartStop() {
            return true;
        }

        private void DispatcherTimerTick(object sender, EventArgs e) {
            _notLoggedTimeInSeconds++;
            UpdateNotLoggedTimeAsString();
            UpdateTimePercents();
            LogTimeCommand.RaiseCanExecuteChanged();
        }

        private void LogTime() {
            _issue.AddWorklogAsync(SecondsToLoggableTimeString(_notLoggedTimeInSeconds)).GetAwaiter().GetResult();
            _issue.SaveChanges();

            Reset();
        }

        private void Reset() {
            _notLoggedTimeInSeconds = 0;
            NotLoggedTime = "0m";
            _timeTrackingData = _issue.GetTimeTrackingData();
            UpdateTimePercents();
            UpdateNotLoggedTimeAsString();
        }

        private string SecondsToLoggableTimeString(int seconds) {
            TimeSpan notLoggedSpan = TimeSpan.FromSeconds(seconds);
            IList<string> components = new List<string>();
            components.Add(Math.Floor(notLoggedSpan.TotalHours) + "h");
            components.Add(notLoggedSpan.Minutes + "m");
            return string.Join(" ", components);
        }

        private string SecondsToViewableTimeString(int seconds) {
            TimeSpan notLoggedSpan = TimeSpan.FromSeconds(seconds);
            IList<string> components = new List<string>();
            components.Add(Math.Floor(notLoggedSpan.TotalHours) + "h");
            components.Add(notLoggedSpan.Minutes + "m");
            components.Add(notLoggedSpan.Seconds + "s");
            return string.Join(" ", components);
        }

        private void StartStop() {
            if (_dispatcherTimer.IsEnabled) {
                _dispatcherTimer.Stop();
                _dispatcherTimer.IsEnabled = false;
            } else {
                _dispatcherTimer.IsEnabled = true;
                _dispatcherTimer.Start();
            }
        }

        private void UpdateNotLoggedTimeAsString() {
            NotLoggedTime = SecondsToViewableTimeString(_notLoggedTimeInSeconds);
        }

        private void UpdateTimePercents() {
            int secondsEstimated = _timeTrackingData.OriginalEstimateInSeconds;
            int secondsLogged = _timeTrackingData.TimeSpentInSeconds;
            int secondsNotLogged = _notLoggedTimeInSeconds;
            if (secondsEstimated == secondsLogged + secondsNotLogged) {
                PercentEstimated = 100;
                PercentLoggedIncludeNotLogged = 100;
                PercentLogged = ((double)secondsLogged / secondsEstimated) * 100;
            } else if (secondsEstimated > secondsLogged + secondsNotLogged) {
                PercentEstimated = 100;
                PercentLogged = ((double)secondsLogged / secondsEstimated) * 100;
                PercentLoggedIncludeNotLogged = ((double)(secondsLogged + secondsNotLogged) / secondsEstimated) * 100;
            } else {
                if (secondsNotLogged == 0) {
                    PercentLogged = 100;
                    PercentEstimated = ((double)secondsEstimated / secondsLogged) * 100;
                } else {
                    PercentLoggedIncludeNotLogged = 100;
                    PercentEstimated = ((double)secondsEstimated / (secondsLogged + secondsNotLogged)) * 100;
                    PercentLogged = ((double)secondsLogged / (secondsLogged + secondsNotLogged)) * 100;
                }
            }

            Estimated = _timeTrackingData.OriginalEstimate;
            Logged = _timeTrackingData.TimeSpent;
            LoggedIncludeNotLogged = SecondsToLoggableTimeString(secondsLogged + secondsNotLogged);
        }
    }
}