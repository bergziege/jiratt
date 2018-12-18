using Atlassian.Jira;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch.ViewModels {
    /// <summary>
    ///     View Model für ein Jira Projekt
    /// </summary>
    public class JiraProjectViewModel : BindableBase, IJiraProjectViewModel {
        /// <summary>
        /// </summary>
        /// <param name="project"></param>
        public JiraProjectViewModel(Project project) {
            Project = project;
            Key = Project.Key;
            Name = Project.Name;
        }

        /// <summary>
        ///     Liefert den Schlüssel des Projekts
        /// </summary>
        public string Key { get; }

        /// <summary>
        ///     Liefert den Namen des Projekts
        /// </summary>
        public string Name { get; }

        /// <summary>
        ///     Liefert das Projekt
        /// </summary>
        public Project Project { get; }
    }
}