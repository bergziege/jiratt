using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.TaskDetails.CommitComment {
    public interface ICommitCommentViewModel {
        DelegateCommand CopyCommitCommentToClipboardCommand { get; }

        void LoadData(Issue issue);
    }
}