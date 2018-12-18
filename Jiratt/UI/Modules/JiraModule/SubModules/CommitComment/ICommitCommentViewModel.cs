using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.JiraModule.SubModules.CommitComment {
    public interface ICommitCommentViewModel {
        DelegateCommand CopyCommitCommentToClipboardCommand { get; }

        void LoadData(Issue issue);
    }
}