using System.Collections.Generic;
using System.Text;

using Atlassian.Jira;

namespace JiraReleaseNoteCreator.ChangelogModel {
    public class IssueTypeModel {
        private IssueType _issueType;
        private IList<IssueModel> _issues = new List<IssueModel>();

        public IssueType IssueType {
            get { return _issueType; }
            set { _issueType = value; }
        }
        public IList<IssueModel> Issues {
            get { return _issues; }
            set { _issues = value; }
        }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
        /// </summary>
        /// <returns>
        /// Eine Zeichenfolge, die das aktuelle Objekt darstellt.
        /// </returns>
        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.Append("  ").AppendLine(_issueType.Name);
            foreach (IssueModel issueModel in _issues) {
                builder.Append(issueModel);
            }
            return builder.ToString();
        }
    }
}