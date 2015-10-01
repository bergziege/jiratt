using System.Collections.ObjectModel;

using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

using JiraReleaseNoteCreator.Ui.TabItem;
using JiraReleaseNoteCreator.Ui.TabItem.ViewModels;

namespace JiraReleaseNoteCreator.Ui.MainView {
    public interface IMainViewModel : IViewModelBase {
        ObservableCollection<Project> Projects { get; set; }

        /// <summary>
        /// </summary>
        RelayCommand SearchIssueByKeyCommand { get; }

        string SearchIssueKey { get; set; }

        Project SelectedProject { get; set; }

        ITabItemViewModel SelectedTabItemViewModel { get; set; }

        ObservableCollection<ITabItemViewModel> TabItems { get; }

        void Init();

        void RemoveTab(TabItemViewModel tabItemViewModel);
    }
}