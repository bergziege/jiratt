using System;

using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.CommitComment;
using JiraReleaseNoteCreator.Ui.TimeTracking;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.IssueTabItem.ViewModels {
    public class IssueTabItemViewModel: BindableBase, IIssueTabItemViewModel {
        private Jira _jira;
        private Issue _selectedIssue;
        private IssueTimeTrackingData _selectedIssueTimeTrackingData;
        private ITimeTrackingViewModel _timeTrackingViewModel;
        private Project _project;
        private ICommitCommentViewModel _commitCommentViewModel;

        /// <summary>
        /// Initialisiert eine neue Instanz der <see cref="T:System.Object"/>-Klasse.
        /// </summary>
        public IssueTabItemViewModel(Jira jira, ITimeTrackingViewModel timeTrackingViewModel, ICommitCommentViewModel commitCommentViewModel) {
            _jira = jira;
            TimeTrackingViewModel = timeTrackingViewModel;
            CommitCommentViewModel = commitCommentViewModel;
        }

        public Issue SelectedIssue {
            get { return _selectedIssue; }
            set {
                _selectedIssue = value;
                RaisePropertyChanged(nameof(SelectedIssue));
                if (_selectedIssue != null) {
                    SelectedIssueTimeTrackingData = _selectedIssue.GetTimeTrackingDataAsync().GetAwaiter().GetResult();
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

        public ICommitCommentViewModel CommitCommentViewModel {
            get { return _commitCommentViewModel; }
            set { _commitCommentViewModel = value;
                RaisePropertyChanged(nameof(CommitCommentViewModel));
            }
        }

        public void LoadData(Project project, Issue issue) {
            if (project == null) {
                throw new ArgumentNullException("project");
            }
            if (issue == null) {
                throw new ArgumentNullException("issue");
            }
            _project = project;
            SelectedIssue = issue;
            CommitCommentViewModel.LoadData(SelectedIssue);
        }
    }
}