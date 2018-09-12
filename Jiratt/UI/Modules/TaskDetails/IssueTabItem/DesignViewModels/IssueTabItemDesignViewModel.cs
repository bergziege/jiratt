using System;
using Atlassian.Jira;
using JiraReleaseNoteCreator.Ui.TimeTracking;
using JiraReleaseNoteCreator.Ui.TimeTracking.DesignViewModels;
using Jiratt.UI.Modules.TaskDetails.CommitComment;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.TaskDetails.IssueTabItem.DesignViewModels {
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
        public void LoadData(string issueKey) {
            throw new NotImplementedException();
        }
    }
}