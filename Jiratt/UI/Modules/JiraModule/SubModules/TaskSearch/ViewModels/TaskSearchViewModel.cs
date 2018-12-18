using System;
using System.Collections.ObjectModel;
using System.Linq;
using Atlassian.Jira;
using Jiratt.Common;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch.ViewModels {
    /// <summary>
    ///     View Model zur Suche und Auswahl eines Vorganges
    /// </summary>
    public class TaskSearchViewModel : BindableBase, ITaskSearchViewModel, INavigationAware {
        private readonly Jira _jiraClient;
        private string _issueNumber;
        private IJiraIssueViewModel _selectedIssue;
        private IJiraProjectViewModel _selectedProject;
        private RelayCommand _showDetailsCommand;

        /// <summary>
        /// </summary>
        /// <param name="jiraClient"></param>
        public TaskSearchViewModel(Jira jiraClient) {
            _jiraClient = jiraClient;
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
        public string IssueNumber {
            private get { return _issueNumber; }
            set {
                SetProperty(ref _issueNumber, value);
                RefreshIssues();
            }
        }

        /// <summary>
        ///     Setzt den gewählten Vorgang
        /// </summary>
        public IJiraIssueViewModel SelectedIssue {
            private get { return _selectedIssue; }
            set { SetProperty(ref _selectedIssue, value); }
        }

        /// <summary>
        ///     Setzt das Ausgewählte Projekt
        /// </summary>
        public IJiraProjectViewModel SelectedProject {
            private get { return _selectedProject; }
            set { SetProperty(ref _selectedProject, value, nameof(SelectedProject)); }
        }

        /// <summary>
        ///     Liefert ein Command um den gewählten Vorgang auszuwählen
        /// </summary>
        public RelayCommand ShowDetailsCommand {
            get { return _showDetailsCommand ?? (_showDetailsCommand = new RelayCommand(ShowDetails, CanShowDetails)); }
        }

        /// <summary>
        ///     Called to determine if this instance can handle the navigation request.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        /// <returns>
        ///     <see langword="true" /> if this instance accepts the navigation request; otherwise, <see langword="false" />.
        /// </returns>
        public bool IsNavigationTarget(NavigationContext navigationContext) {
            return true;
        }

        /// <summary>
        ///     Called when the implementer is being navigated away from.
        /// </summary>
        /// <param name="navigationContext">The navigation context.</param>
        public void OnNavigatedFrom(NavigationContext navigationContext) {
        }

        /// <summary>Called when the implementer has been navigated to.</summary>
        /// <param name="navigationContext">The navigation context.</param>
        public void OnNavigatedTo(NavigationContext navigationContext) {
            RefreshProjects();
        }

        private bool CanShowDetails() {
            return SelectedIssue != null;
        }

        private async void RefreshIssues() {
            AvailableIssues.Clear();
            if (SelectedProject != null) {
                try {
                    Issue issue = await _jiraClient.Issues.GetIssueAsync(SelectedProject.Key + "-" + IssueNumber);
                    AvailableIssues.Add(new JiraIssueViewModel(issue));
                } catch (InvalidOperationException) {
                    /* Z.B: Vorgang nicht gefunden */
                }
            }
        }

        private async void RefreshProjects() {
            AvailableProjects.Clear();
            foreach (Project project in (await _jiraClient.Projects.GetProjectsAsync()).OrderBy(x => x.Key)) {
                AvailableProjects.Add(new JiraProjectViewModel(project));
            }
        }

        private void ShowDetails() {
        }
    }
}