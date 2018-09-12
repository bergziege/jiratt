using System.Runtime.Remoting.Messaging;

using Atlassian.Jira;

using JiraReleaseNoteCreator.Ui.IssueTabItem.DesignViewModels;
using JiraReleaseNoteCreator.Ui.MainView;
using Prism.Commands;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.TabItem.DesignViewModels {
    public class TabItemDesignViewModel: BindableBase, ITabItemViewModel {
        public TabItemDesignViewModel(BindableBase content, string header) {
            Content = content;
            HeaderText = header;
        }

        public BindableBase Content { get; private set; }

        public string HeaderText { get; private set; }

        public void LoadData(Project project, string contentKey, IMainViewModel mainViewModel) {
        }

        public DelegateCommand CloseTabCommand { get; private set; }

        public string SearchKey { get; private set; }

        public Project Project { get; private set; }
    }
}