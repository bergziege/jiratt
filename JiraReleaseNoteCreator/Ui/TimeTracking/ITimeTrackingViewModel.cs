using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

namespace JiraReleaseNoteCreator.Ui.TimeTracking {
    public interface ITimeTrackingViewModel : IViewModelBase {
        string Estimated { get; }

        string Logged { get; }

        double PercentEstimated { get; }

        double PercentLogged { get; }

        double PercentLoggedIncludeNotLogged { get; }

        void LoadData(Issue issue);

        RelayCommand StartStopCommand { get; }

        string NotLoggedTime { get; }

        string LoggedIncludeNotLogged { get; }

        RelayCommand LogTimeCommand { get; }

        RelayCommand ResetCommand { get; }
    }
}