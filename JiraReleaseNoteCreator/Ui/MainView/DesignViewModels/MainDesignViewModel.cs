using System.Collections.ObjectModel;

using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.ChangelogTabItem.DesignViewModels;
using JiraReleaseNoteCreator.Ui.IssueTabItem.DesignViewModels;
using JiraReleaseNoteCreator.Ui.TabItem;
using JiraReleaseNoteCreator.Ui.TabItem.DesignViewModels;
using JiraReleaseNoteCreator.Ui.TabItem.ViewModels;
using Prism.Commands;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.MainView.DesignViewModels {
    public class MainDesignViewModel : BindableBase, IMainViewModel{
        public MainDesignViewModel() {
            
            TabItems = new ObservableCollection<ITabItemViewModel>();
            TabItems.Add(new TabItemDesignViewModel(new ChangelogTabItemDesignViewModel(), "changelog"));
            TabItems.Add(new TabItemDesignViewModel(new IssueTabItemDesignViewModel(), "issue"));
            
        }

        public ObservableCollection<Project> Projects { get; set; }

        public DelegateCommand SearchIssueByKeyCommand { get; private set; }

        public string SearchIssueKey { get; set; }

        public Project SelectedProject { get; set; }

        public ITabItemViewModel SelectedTabItemViewModel { get; set; }

        public void Init() {
        }

        public void RemoveTab(TabItemViewModel tabItemViewModel) {
        }

        public ObservableCollection<ITabItemViewModel> TabItems { get; private set; }
    }
}