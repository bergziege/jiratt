using System.Collections.ObjectModel;
using System.Linq;

using Atlassian.Jira;

using Com.QueoFlow.Commons;
using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

using DryIoc;

using JiraReleaseNoteCreator.Ui.TabItem;
using JiraReleaseNoteCreator.Ui.TabItem.ViewModels;

namespace JiraReleaseNoteCreator.Ui.MainView.ViewModels {
    public class MainViewModel : ViewModelBase, IMainViewModel {
        private readonly ObservableCollection<ITabItemViewModel> _tabItems = new ObservableCollection<ITabItemViewModel>();
        private Jira _jira;
        private ObservableCollection<Project> _projects = new ObservableCollection<Project>();
        private RelayCommand _searchIssueByKeyCommand;
        private string _searchIssueKey;
        private Project _selectedProject;
        private ITabItemViewModel _selectedTabItemViewModel;

        public ObservableCollection<Project> Projects {
            get { return _projects; }
            set { _projects = value; }
        }

        /// <summary>
        /// </summary>
        public RelayCommand SearchIssueByKeyCommand {
            get {
                if (_searchIssueByKeyCommand == null) {
                    _searchIssueByKeyCommand = new RelayCommand("", CreateTab);
                }

                return _searchIssueByKeyCommand;
            }
        }

        public string SearchIssueKey {
            get { return _searchIssueKey; }
            set {
                _searchIssueKey = value;
                OnPropertyChanged(this.GetPropertyName(x => x.SearchIssueKey));
            }
        }

        public Project SelectedProject {
            get { return _selectedProject; }
            set {
                _selectedProject = value;
                OnPropertyChanged(this.GetPropertyName(x => x.SelectedProject));
            }
        }

        public ITabItemViewModel SelectedTabItemViewModel {
            get { return _selectedTabItemViewModel; }
            set { _selectedTabItemViewModel = value; OnPropertyChanged(this.GetPropertyName(x => x.SelectedTabItemViewModel)); }
        }

        public ObservableCollection<ITabItemViewModel> TabItems {
            get { return _tabItems; }
        }

        public void Init() {
            _jira = AppContext.Instance.Container.Resolve<Jira>();
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