using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.TaskSearch.ViewModels {
    /// <summary>
    ///     View Model zur Suche und Auswahl eines Vorganges
    /// </summary>
    public class TaskSearchViewModel : BindableBase, ITaskSearchViewModel {
        public ObservableCollection<IJiraIssueViewModel> AvailableIssues { get; }
        public ObservableCollection<IJiraProjectViewModel> AvailableProjects { get; }
        public string IssueNumber { get; set; }
        public IJiraIssueViewModel SelectedIssue { get; set; }
        public IJiraProjectViewModel SelectedProject { get; set; }
        public DelegateCommand SelectIssueCommand { get; }
    }
}