using System.Collections.Generic;
using System.Text;

namespace JiraReleaseNoteCreator.ChangelogModel {
    public class VersionModel {
        private IList<IssueTypeModel> _issueTypes = new List<IssueTypeModel>();

        public IList<IssueTypeModel> IssueTypes {
            get { return _issueTypes; }
            set { _issueTypes = value; }
        }

        public string Version { get; set; }

        /// <summary>
        /// Gibt eine Zeichenfolge zurück, die das aktuelle Objekt darstellt.
        /// </summary>
        /// <returns>
        /// Eine Zeichenfolge, die das aktuelle Objekt darstellt.
        /// </returns>
        public override string ToString() {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("Änderungen in Version: ").AppendLine(Version);
            foreach (IssueTypeModel issueTypeModel in _issueTypes) {
                stringBuilder.Append(issueTypeModel);
            }
            stringBuilder.AppendLine();
            return stringBuilder.ToString();
        } 
    }
}