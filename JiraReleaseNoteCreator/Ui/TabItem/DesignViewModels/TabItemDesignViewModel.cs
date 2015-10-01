using System.Runtime.Remoting.Messaging;

using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

using JiraReleaseNoteCreator.Ui.IssueTabItem.DesignViewModels;
using JiraReleaseNoteCreator.Ui.MainView;

namespace JiraReleaseNoteCreator.Ui.TabItem.DesignViewModels {
    public class TabItemDesignViewModel: ViewModelBase, ITabItemViewModel {
        public TabItemDesignViewModel(IViewModelBase content, string header) {
            Content = content;
            HeaderText = header;
        }

        public IViewModelBase Content { get; private set; }

        public string HeaderText { get; private set; }

        public void LoadData(Project project, string contentKey, IMainViewModel mainViewModel) {
        }

        public RelayCommand CloseTabCommand { get; private set; }

        public string SearchKey { get; private set; }

        public Project Project { get; private set; }
    }
}