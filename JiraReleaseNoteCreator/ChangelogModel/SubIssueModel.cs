using Atlassian.Jira;

namespace JiraReleaseNoteCreator.ChangelogModel {
    public class SubIssueModel {
        private Issue _issue;

        public Issue Issue {
            get { return _issue; }
            set { _issue = value; }
        }
    }
}