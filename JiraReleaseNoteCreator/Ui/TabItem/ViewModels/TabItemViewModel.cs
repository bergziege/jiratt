using System;
using System.Linq;
using Atlassian.Jira;
using JiraReleaseNoteCreator.Ui.ChangelogTabItem;
using JiraReleaseNoteCreator.Ui.IssueTabItem;
using JiraReleaseNoteCreator.Ui.MainView;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.TabItem.ViewModels {
    public class TabItemViewModel : BindableBase, ITabItemViewModel {
        private readonly IUnityContainer _container;
        private readonly Jira _jira;
        private DelegateCommand _closeTabCommand;
        private BindableBase _content;
        private string _contentKey;
        private string _headerText;
        private IMainViewModel _mainViewModel;
        private Project _project;

        public TabItemViewModel(Jira jira, IUnityContainer container) {
            _jira = jira;
            _container = container;
        }

        public DelegateCommand CloseTabCommand {
            get {
                if (_closeTabCommand == null) {
                    _closeTabCommand = new DelegateCommand(CloseTab, CanCloseTab);
                }

                return _closeTabCommand;
            }
        }

        public BindableBase Content {
            get { return _content; }
            private set {
                _content = value;
                RaisePropertyChanged(nameof(Content));
            }
        }

        public string HeaderText {
            get { return _headerText; }
            private set {
                _headerText = value;
                RaisePropertyChanged(nameof(HeaderText));
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
            IChangelogTabItemViewModel changelogTabItemViewModel = _container.Resolve<IChangelogTabItemViewModel>();
            changelogTabItemViewModel.LoadData(_project);
            Content = (BindableBase)changelogTabItemViewModel;
        }

        private void SetIssueDetailContent(Issue issue) {
            HeaderText = issue.Key.ToString();
            IIssueTabItemViewModel issueTabItemViewModel = _container.Resolve<IIssueTabItemViewModel>();
            issueTabItemViewModel.LoadData(_project, issue);
            Content = (BindableBase)issueTabItemViewModel;
        }
    }
}