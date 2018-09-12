using Atlassian.Jira;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.TaskSearch.DesignViewModels {
    /// <summary>
    ///     Design View Model für ein Jira Vorgang
    /// </summary>
    public class JiraIssueDesignViewModel : BindableBase, IJiraIssueViewModel {
        /// <summary>
        /// </summary>
        public JiraIssueDesignViewModel() {
        }

        /// <summary>
        /// </summary>
        /// <param name="type"></param>
        /// <param name="key"></param>
        /// <param name="summary"></param>
        public JiraIssueDesignViewModel(string type, string key, string summary) {
            TypeName = type;
            Key = key;
            Summary = summary;
        }

        /// <summary>
        ///     Liefert den Vorgang
        /// </summary>
        public Issue Issue { get; }

        /// <summary>
        ///     Liefert den Schlüssel (Projektschlüssel + Vorgangsnummer)
        /// </summary>
        public string Key { get; } = "PROJECT42-84";

        /// <summary>
        ///     Liefert die Zusammenfassung zum Vorgang
        /// </summary>
        public string Summary { get; } = "Dies ist ein falscher Fehler";

        /// <summary>
        ///     Liefert den Vorgangstypen
        /// </summary>
        public string TypeName { get; } = "Bug";
    }
}