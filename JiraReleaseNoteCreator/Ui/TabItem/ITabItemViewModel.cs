using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.MainView;
using Prism.Commands;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.TabItem {
    public interface ITabItemViewModel {
        BindableBase Content { get; }

        string HeaderText { get; }

        void LoadData(Project project, string contentKey, IMainViewModel mainViewModel);

        DelegateCommand CloseTabCommand { get; }

        string SearchKey { get; }

        Project Project { get; }
    }
}