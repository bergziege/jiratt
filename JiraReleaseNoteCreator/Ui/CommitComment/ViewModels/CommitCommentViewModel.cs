using System.Windows;

using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.Commands;
using Com.QueoFlow.Commons.MVVM.ViewModels;

namespace JiraReleaseNoteCreator.Ui.CommitComment.ViewModels {
    public class CommitCommentViewModel: ViewModelBase, ICommitCommentViewModel {
        
        public RelayCommand CopyCommitCommentToClipboardCommand {
            get {
                if (_copyCommitCommentToClipboardCommand == null)
                    _copyCommitCommentToClipboardCommand = new RelayCommand("", CopyCommitCommentToClipboard);

                return _copyCommitCommentToClipboardCommand;
            }
        }

        public void LoadData(Issue issue) {
            _issue = issue;
        }

        private RelayCommand _copyCommitCommentToClipboardCommand;
        private Issue _issue;

        private void CopyCommitCommentToClipboard() {
            Clipboard.SetText("[" + _issue.Key + "] - " + _issue.Summary);
        }		

        
    }
}