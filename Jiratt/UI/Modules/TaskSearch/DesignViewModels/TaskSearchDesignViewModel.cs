using System.Collections.ObjectModel;
using System.Linq;
using Jiratt.Common;
using Prism.Commands;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.TaskSearch.DesignViewModels {
    /// <summary>
    ///     Design View Model einer Ansicht zur Suche und Auswahl eines Vorganges
    /// </summary>
    public class TaskSearchDesignViewModel : BindableBase, ITaskSearchViewModel {
        /// <summary>
        /// </summary>
        public TaskSearchDesignViewModel() {
            AvailableIssues.Add(new JiraIssueDesignViewModel("Bug", "PROJECT42-4", "Das ist ein falscher fehler"));
            AvailableIssues.Add(new JiraIssueDesignViewModel("Feature", "PROJECT-42", "Das ist ein neuer falscher Fehler"));
            AvailableIssues.Add(new JiraIssueDesignViewModel("Aufgabe", "PROJECT-424", "Und hier soll noch jemand ein viel längeren falschen Fehler einbauen, damit wir auch in Zukunft was z utun haben ;-)"));
            SelectedIssue = AvailableIssues[1];

            AvailableProjects.Add(new JiraProjectDesignViewModel());
            AvailableProjects.Add(new JiraProjectDesignViewModel());
            SelectedProject = AvailableProjects.First();
        }

        /// <summary>
        ///     Liefert die zur Vorgangsnummer passenden Vorgänge
        /// </summary>
        public ObservableCollection<IJiraIssueViewModel> AvailableIssues { get; } = new ObservableCollection<IJiraIssueViewModel>();

        /// <summary>
        ///     Liefert die Liste der zur Auswahl stehenden Projekte
        /// </summary>
        public ObservableCollection<IJiraProjectViewModel> AvailableProjects { get; } = new ObservableCollection<IJiraProjectViewModel>();

        /// <summary>
        ///     Setzt die Vorgangsnummer
        /// </summary>
        public string IssueNumber { get; set; } = "42";

        /// <summary>
        ///     Setzt den gewählten Vorgang
        /// </summary>
        public IJiraIssueViewModel SelectedIssue { get; set; }

        /// <summary>
        ///     Setzt das Ausgewählte Projekt
        /// </summary>
        public IJiraProjectViewModel SelectedProject { get; set; }

        /// <summary>
        ///     Liefert ein Command um den gewählten Vorgang auszuwählen
        /// </summary>
        public RelayCommand ShowDetailsCommand { get; }
    }
}