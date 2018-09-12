using Atlassian.Jira;
using Prism.Commands;

namespace JiraReleaseNoteCreator.Ui.CommitComment {
    public interface ICommitCommentViewModel {
        DelegateCommand CopyCommitCommentToClipboardCommand { get; }

        void LoadData(Issue issue);
    }
}