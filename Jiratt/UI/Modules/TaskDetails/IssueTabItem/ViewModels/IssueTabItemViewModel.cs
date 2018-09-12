using Atlassian.Jira;
using JiraReleaseNoteCreator.Ui.TimeTracking;
using Jiratt.UI.Modules.TaskDetails.CommitComment;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.TaskDetails.IssueTabItem.ViewModels {
    public class IssueTabItemViewModel : BindableBase, IIssueTabItemViewModel {
        private ICommitCommentViewModel _commitCommentViewModel;
        private readonly Jira _jira;
        private Issue _selectedIssue;
        private IssueTimeTrackingData _selectedIssueTimeTrackingData;
        private ITimeTrackingViewModel _timeTrackingViewModel;

        /// <summary>
        ///     Initialisiert eine neue Instanz der <see cref="T:System.Object" />-Klasse.
        /// </summary>
        public IssueTabItemViewModel(Jira jira, ITimeTrackingViewModel timeTrackingViewModel, ICommitCommentViewModel commitCommentViewModel) {
            _jira = jira;
            TimeTrackingViewModel = timeTrackingViewModel;
            CommitCommentViewModel = commitCommentViewModel;
        }

        public ICommitCommentViewModel CommitCommentViewModel {
            get { return _commitCommentViewModel; }
            set {
                _commitCommentViewModel = value;
                RaisePropertyChanged(nameof(CommitCommentViewModel));
            }
        }

        public Issue SelectedIssue {
            get { return _selectedIssue; }
            set {
                _selectedIssue = value;
                RaisePropertyChanged(nameof(SelectedIssue));
                if (_selectedIssue != null) {
                    SelectedIssueTimeTrackingData = _selectedIssue.GetTimeTrackingData();
                    TimeTrackingViewModel.LoadData(_selectedIssue);
                } else {
                    SelectedIssueTimeTrackingData = null;
                }
            }
        }

        public IssueTimeTrackingData SelectedIssueTimeTrackingData {
            get { return _selectedIssueTimeTrackingData; }
            set {
                _selectedIssueTimeTrackingData = value;
                RaisePropertyChanged(nameof(SelectedIssueTimeTrackingData));
            }
        }

        /// <summary>
        ///     Liefert ein <see cref="ITimeTrackingViewModel" />
        /// </summary>
        public ITimeTrackingViewModel TimeTrackingViewModel {
            get { return _timeTrackingViewModel; }
            set {
                if (_timeTrackingViewModel != value) {
                    _timeTrackingViewModel = value;
                    RaisePropertyChanged(nameof(TimeTrackingViewModel));
                }
            }
        }

        public void LoadData(string issueKey) {
            SelectedIssue = _jira.Issues.GetIssueAsync(issueKey).GetAwaiter().GetResult();
            CommitCommentViewModel.LoadData(SelectedIssue);
        }
    }
}