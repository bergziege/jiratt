using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

using JiraReleaseNoteCreator.Ui.MainView;

namespace JiraReleaseNoteCreator.Ui.TabItem {
    public interface ITabItemViewModel : IViewModelBase {
        IViewModelBase Content { get; }

        string HeaderText { get; }

        void LoadData(Project project, string contentKey, IMainViewModel mainViewModel);

        RelayCommand CloseTabCommand { get; }

        string SearchKey { get; }

        Project Project { get; }
    }
}