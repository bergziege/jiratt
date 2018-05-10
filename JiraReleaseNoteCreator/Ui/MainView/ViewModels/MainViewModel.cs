using System.Collections.ObjectModel;
using System.Linq;

using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.TabItem;
using JiraReleaseNoteCreator.Ui.TabItem.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.MainView.ViewModels {
    public class MainViewModel : BindableBase, IMainViewModel {
        private readonly ObservableCollection<ITabItemViewModel> _tabItems = new ObservableCollection<ITabItemViewModel>();
        private Jira _jira;
        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        private DelegateCommand _searchIssueByKeyCommand;
        private string _searchIssueKey;
        private Project _selectedProject;
        private ITabItemViewModel _selectedTabItemViewModel;

        public ObservableCollection<Project> Projects {
            get { return _projects; }
            set { _projects = value; }
        }

        /// <summary>
        /// </summary>
        public DelegateCommand SearchIssueByKeyCommand {
            get {
                if (_searchIssueByKeyCommand == null) {
                    _searchIssueByKeyCommand = new DelegateCommand(CreateTab);
                }

                return _searchIssueByKeyCommand;
            }
        }

        public string SearchIssueKey {
            get { return _searchIssueKey; }
            set {
                _searchIssueKey = value;
                RaisePropertyChanged(nameof(SearchIssueKey));
            }
        }

        public Project SelectedProject {
            get { return _selectedProject; }
            set {
                _selectedProject = value;
                RaisePropertyChanged(nameof(SelectedProject));
            }
        }

        public ITabItemViewModel SelectedTabItemViewModel {
            get { return _selectedTabItemViewModel; }
            set { _selectedTabItemViewModel = value;
                RaisePropertyChanged(nameof(SelectedTabItemViewModel));
            }
        }

        public ObservableCollection<ITabItemViewModel> TabItems {
            get { return _tabItems; }
        }

        public void Init() {
            _jira = (Jira) AppContext.Instance.Container.Resolve(typeof(Jira));
            FillProjects();
        }

        public void RemoveTab(TabItemViewModel tabItemViewModel) {
            _tabItems.Remove(tabItemViewModel);
        }

        private void CreateTab() {

            ITabItemViewModel tabItemViewModel = _tabItems.FirstOrDefault(x => x.Project == SelectedProject && x.SearchKey == SearchIssueKey);

            if (tabItemViewModel == null) {
                tabItemViewModel = AppContext.Instance.Container.Resolve<ITabItemViewModel>();
                tabItemViewModel.LoadData(SelectedProject, SearchIssueKey, this);
                _tabItems.Add(tabItemViewModel);
            }
            SelectedTabItemViewModel = tabItemViewModel;
        }

        private async void FillProjects() {
            Projects.Clear();
            foreach (Project project in (await _jira.Projects.GetProjectsAsync()).OrderBy(x=>x.Name)) {
                _projects.Add(project);
            }
        }
    }
}