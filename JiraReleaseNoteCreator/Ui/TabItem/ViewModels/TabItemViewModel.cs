using System;
using System.Linq;

using Atlassian.Jira;

using Com.QueoFlow.Commons;
using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

using DryIoc;

using JiraReleaseNoteCreator.Ui.ChangelogTabItem;
using JiraReleaseNoteCreator.Ui.IssueTabItem;
using JiraReleaseNoteCreator.Ui.MainView;

namespace JiraReleaseNoteCreator.Ui.TabItem.ViewModels {
    public class TabItemViewModel : ViewModelBase, ITabItemViewModel {
        private readonly Jira _jira;
        private RelayCommand _closeTabCommand;
        private IViewModelBase _content;
        private string _contentKey;
        private string _headerText;
        private IMainViewModel _mainViewModel;
        private Project _project;

        public TabItemViewModel(Jira jira) {
            _jira = jira;
        }

        public RelayCommand CloseTabCommand {
            get {
                if (_closeTabCommand == null) {
                    _closeTabCommand = new RelayCommand("", CloseTab, CanCloseTab);
                }

                return _closeTabCommand;
            }
        }

        public IViewModelBase Content {
            get { return _content; }
            private set {
                _content = value;
                OnPropertyChanged(this.GetPropertyName(x => x.Content));
            }
        }

        public string HeaderText {
            get { return _headerText; }
            private set {
                _headerText = value;
                OnPropertyChanged(this.GetPropertyName(x => x.HeaderText));
            }
        }

        public Project Project {
            get { return _project; }
        }
        public string SearchKey {
            get { return _contentKey; }
        }

        public void LoadData(Project project, string contentKey, IMainViewModel mainViewModel) {
            if (project == null) {
                throw new ArgumentNullException("project");
            }
            if (contentKey == null) {
                throw new ArgumentNullException("contentKey");
            }
            _project = project;
            _contentKey = contentKey;
            _mainViewModel = mainViewModel;

            CreateContentByKey();
        }

        private bool CanCloseTab() {
            return true;
        }

        private void CloseTab() {
            _mainViewModel.RemoveTab(this);
        }

        private void CreateContentByKey() {
            if (_contentKey == "changelog") {
                SetChangelogContent();
            } else {
                int issueKey;
                if (int.TryParse(_contentKey, out issueKey)) {
                    Issue issue = SearchIssueByKey(issueKey);
                    if (issue != null) {
                        SetIssueDetailContent(issue);
                    }
                }
            }
        }

        private Issue SearchIssueByKey(int issueKey) {
            IOrderedQueryable<Issue> issues = from i in _jira.Issues.Queryable
                where i.Key == _project.Key + "-" + issueKey
                orderby i.Created
                select i;
            try {
                return issues.FirstOrDefault();
            } catch (Exception) {
                return null;
            }
        }

        private void SetChangelogContent() {
            HeaderText = "Changelog " + _project.Key;
            IChangelogTabItemViewModel changelogTabItemViewModel = AppContext.Instance.Container.Resolve<IChangelogTabItemViewModel>();
            changelogTabItemViewModel.LoadData(_project);
            Content = changelogTabItemViewModel;
        }

        private void SetIssueDetailContent(Issue issue) {
            HeaderText = issue.Key.ToString();
            IIssueTabItemViewModel issueTabItemViewModel = AppContext.Instance.Container.Resolve<IIssueTabItemViewModel>();
            issueTabItemViewModel.LoadData(_project, issue);
            Content = issueTabItemViewModel;
        }
    }
}