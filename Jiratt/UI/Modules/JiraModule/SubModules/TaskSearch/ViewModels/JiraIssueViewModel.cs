using Atlassian.Jira;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch.ViewModels {
    /// <summary>
    ///     View Model eines Jira Vorgangs
    /// </summary>
    public class JiraIssueViewModel : BindableBase, IJiraIssueViewModel {
        /// <summary>
        /// </summary>
        /// <param name="issue"></param>
        public JiraIssueViewModel(Issue issue) {
            Issue = issue;
            Key = Issue.Key.Value;
            Summary = Issue.Summary;
            TypeName = Issue.Type.Name;
        }

        /// <summary>
        ///     Liefert den Vorgang
        /// </summary>
        public Issue Issue { get; }

        /// <summary>
        ///     Liefert den Schlüssel (Projektschlüssel + Vorgangsnummer)
        /// </summary>
        public string Key { get; }

        /// <summary>
        ///     Liefert die Zusammenfassung zum Vorgang
        /// </summary>
        public string Summary { get; }

        /// <summary>
        ///     Liefert den Vorgangstypen
        /// </summary>
        public string TypeName { get; }
    }
}