using Atlassian.Jira;

namespace Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch {
    /// <summary>
    ///     Schnittstelle für View Models für ein Jira Projekt
    /// </summary>
    public interface IJiraProjectViewModel {
        /// <summary>
        ///     Liefert den Schlüssel des Projekts
        /// </summary>
        string Key { get; }

        /// <summary>
        ///     Liefert den Namen des Projekts
        /// </summary>
        string Name { get; }

        /// <summary>
        ///     Liefert das Projekt
        /// </summary>
        Project Project { get; }
    }
}