using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

namespace JiraReleaseNoteCreator.Ui.CommitComment {
    public interface ICommitCommentViewModel : IViewModelBase {
        RelayCommand CopyCommitCommentToClipboardCommand { get; }

        void LoadData(Issue issue);
    }
}