using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.CommitComment;
using JiraReleaseNoteCreator.Ui.TimeTracking;
using JiraReleaseNoteCreator.Ui.TimeTracking.DesignViewModels;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.IssueTabItem.DesignViewModels {
    public class IssueTabItemDesignViewModel : BindableBase, IIssueTabItemViewModel {
        public IssueTabItemDesignViewModel() {
            TimeTrackingViewModel = new TimeTrackingDesignViewModel();
        }

        public Issue SelectedIssue { get; set; }

        public IssueTimeTrackingData SelectedIssueTimeTrackingData { get; set; }

        /// <summary>
        ///     Liefert ein <see cref="ITimeTrackingViewModel" />
        /// </summary>
        public ITimeTrackingViewModel TimeTrackingViewModel { get; set; }

        public ICommitCommentViewModel CommitCommentViewModel { get; set; }

        public void LoadData(Project project, Issue issue) {
        }
    }
}