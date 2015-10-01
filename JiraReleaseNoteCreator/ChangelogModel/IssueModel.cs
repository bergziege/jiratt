using System.Collections.Generic;
using System.Text;

using Atlassian.Jira;

namespace JiraReleaseNoteCreator.ChangelogModel {
    public class IssueModel {
        private Issue _issue;
        private IList<SubIssueModel> _subIssues = new List<SubIssueModel>();

        public Issue Issue {
            get { return _issue; }
            set { _issue = value; }
        }
        public IList<SubIssueModel> SubIssues {
            get { return _subIssues; }
            set { _subIssues = value; }
        }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
        /// </summary>
        /// <returns>
        /// Eine Zeichenfolge, die das aktuelle Objekt darstellt.
        /// </returns>
        public override string ToString() {
            StringBuilder builder = new StringBuilder();
            builder.Append("    - ").Append(_issue.Key).Append(" - ").AppendLine(_issue.Summary);
            foreach (SubIssueModel subIssueModel in _subIssues) {
                
            }
            return builder.ToString();
        }
    }
}