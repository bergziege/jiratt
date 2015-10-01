﻿using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

namespace JiraReleaseNoteCreator.Ui.TimeTracking.DesignViewModels {
    public class TimeTrackingDesignViewModel : ViewModelBase, ITimeTrackingViewModel {
        public TimeTrackingDesignViewModel() {
            PercentEstimated = 75;
            PercentLogged = 33;
            PercentLoggedIncludeNotLogged = 55;
            Estimated = "2d 4h";
            Logged = "1d 2h 5m";
            NotLoggedTime = "1h 5m";
            LoggedIncludeNotLogged = "1d 3h 10m";
        }

        public string Estimated { get; private set; }

        public string Logged { get; private set; }

        public double PercentEstimated { get; private set; }

        public double PercentLogged { get; private set; }

        public double PercentLoggedIncludeNotLogged { get; private set; }

        public void LoadData(Issue issue) {
        }

        public RelayCommand StartStopCommand { get; private set; }

        public string NotLoggedTime { get; private set; }

        public string LoggedIncludeNotLogged { get; private set; }

        public RelayCommand LogTimeCommand { get; private set; }

        public RelayCommand ResetCommand { get; private set; }
    }
}