using Atlassian.Jira;
using JiraReleaseNoteCreator.Ui.TimeTracking;
using Jiratt.UI.Modules.TaskDetails.CommitComment;

namespace Jiratt.UI.Modules.TaskDetails.IssueTabItem {
    public interface IIssueTabItemViewModel {
        Issue SelectedIssue { get; set; }

        IssueTimeTrackingData SelectedIssueTimeTrackingData { get; set; }

        /// <summary>
        ///     Liefert ein <see cref="ITimeTrackingViewModel" />
        /// </summary>
        ITimeTrackingViewModel TimeTrackingViewModel { get; set; }

        ICommitCommentViewModel CommitCommentViewModel { get; set; }

        void LoadData(string issueKey);
    }
}