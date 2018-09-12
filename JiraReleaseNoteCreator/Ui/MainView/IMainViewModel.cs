using System.Collections.ObjectModel;

using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.TabItem;
using JiraReleaseNoteCreator.Ui.TabItem.ViewModels;
using Prism.Commands;

namespace JiraReleaseNoteCreator.Ui.MainView {
    public interface IMainViewModel {
        ObservableCollection<Project> Projects { get; set; }

        /// <summary>
        /// </summary>
        DelegateCommand SearchIssueByKeyCommand { get; }

        string SearchIssueKey { get; set; }

        Project SelectedProject { get; set; }

        ITabItemViewModel SelectedTabItemViewModel { get; set; }

        ObservableCollection<ITabItemViewModel> TabItems { get; }

        void Init();

        void RemoveTab(TabItemViewModel tabItemViewModel);
    }
}