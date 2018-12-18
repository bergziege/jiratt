using Atlassian.Jira;

namespace Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch {
    /// <summary>
    ///     Schnittstelle für View Models für ein Jira Vorgang
    /// </summary>
    public interface IJiraIssueViewModel {
        /// <summary>
        ///     Liefert den Vorgang
        /// </summary>
        Issue Issue { get; }

        /// <summary>
        ///     Liefert den Schlüssel (Projektschlüssel + Vorgangsnummer)
        /// </summary>
        string Key { get; }

        /// <summary>
        ///     Liefert die Zusammenfassung zum Vorgang
        /// </summary>
        string Summary { get; }

        /// <summary>
        ///     Liefert den Vorgangstypen
        /// </summary>
        string TypeName { get; }
    }
}