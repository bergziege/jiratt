using Atlassian.Jira;

using Prism.Commands;

namespace JiraReleaseNoteCreator.Ui.TimeTracking {
    public interface ITimeTrackingViewModel {
        string Estimated { get; }

        string Logged { get; }

        double PercentEstimated { get; }

        double PercentLogged { get; }

        double PercentLoggedIncludeNotLogged { get; }

        void LoadData(Issue issue);

        DelegateCommand StartStopCommand { get; }

        string NotLoggedTime { get; }

        string LoggedIncludeNotLogged { get; }

        DelegateCommand LogTimeCommand { get; }

        DelegateCommand ResetCommand { get; }
    }
}