using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.CommitComment;
using JiraReleaseNoteCreator.Ui.TimeTracking;

namespace JiraReleaseNoteCreator.Ui.IssueTabItem {
    public interface IIssueTabItemViewModel {
        Issue SelectedIssue { get; set; }

        IssueTimeTrackingData SelectedIssueTimeTrackingData { get; set; }

        /// <summary>
        ///     Liefert ein <see cref="ITimeTrackingViewModel" />
        /// </summary>
        ITimeTrackingViewModel TimeTrackingViewModel { get; set; }

        ICommitCommentViewModel CommitCommentViewModel { get; set; }

        void LoadData(Project project, Issue issue);
    }
}