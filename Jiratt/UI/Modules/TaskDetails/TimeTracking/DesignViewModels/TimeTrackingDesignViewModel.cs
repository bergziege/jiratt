using Atlassian.Jira;
using Prism.Commands;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.TimeTracking.DesignViewModels {
    public class TimeTrackingDesignViewModel : BindableBase, ITimeTrackingViewModel {
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

        public DelegateCommand StartStopCommand { get; private set; }

        public string NotLoggedTime { get; private set; }

        public string LoggedIncludeNotLogged { get; private set; }

        public DelegateCommand LogTimeCommand { get; private set; }

        public DelegateCommand ResetCommand { get; private set; }
    }
}