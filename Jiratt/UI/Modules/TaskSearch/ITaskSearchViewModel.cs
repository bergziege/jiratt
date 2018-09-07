using System.Collections.ObjectModel;
using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.TaskSearch {
    /// <summary>
    ///     Schnittstelle für View Models zur Suche und Auswahl eines Vorganges
    /// </summary>
    public interface ITaskSearchViewModel {
        /// <summary>
        ///     Liefert die zur Vorgangsnummer passenden Vorgänge
        /// </summary>
        ObservableCollection<IJiraIssueViewModel> AvailableIssues { get; }

        /// <summary>
        ///     Liefert die Liste der zur Auswahl stehenden Projekte
        /// </summary>
        ObservableCollection<IJiraProjectViewModel> AvailableProjects { get; }

        /// <summary>
        ///     Setzt die Vorgangsnummer
        /// </summary>
        string IssueNumber { set; }

        /// <summary>
        ///     Setzt den gewählten Vorgang
        /// </summary>
        IJiraIssueViewModel SelectedIssue { set; }

        /// <summary>
        ///     Setzt das Ausgewählte Projekt
        /// </summary>
        IJiraProjectViewModel SelectedProject { set; }

        /// <summary>
        ///     Liefert ein Command um den gewählten Vorgang auszuwählen
        /// </summary>
        DelegateCommand ShowDetailsCommand { get; }
    }
}