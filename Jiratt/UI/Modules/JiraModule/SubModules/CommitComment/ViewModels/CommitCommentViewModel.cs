using System.Windows;
using Atlassian.Jira;
using Prism.Commands;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.JiraModule.SubModules.CommitComment.ViewModels {
    public class CommitCommentViewModel: BindableBase, ICommitCommentViewModel {
        
        public DelegateCommand CopyCommitCommentToClipboardCommand {
            get {
                if (_copyCommitCommentToClipboardCommand == null)
                    _copyCommitCommentToClipboardCommand = new DelegateCommand(CopyCommitCommentToClipboard);

                return _copyCommitCommentToClipboardCommand;
            }
        }

        public void LoadData(Issue issue) {
            _issue = issue;
        }

        private DelegateCommand _copyCommitCommentToClipboardCommand;
        private Issue _issue;

        private void CopyCommitCommentToClipboard() {
            Clipboard.SetText("[" + _issue.Key + "] - " + _issue.Summary);
        }		

        
    }
}