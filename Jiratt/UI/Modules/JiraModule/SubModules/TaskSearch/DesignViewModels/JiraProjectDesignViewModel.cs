using Atlassian.Jira;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch.DesignViewModels {
    /// <summary>
    ///     Design View Model für ein Jira Project
    /// </summary>
    public class JiraProjectDesignViewModel : BindableBase, IJiraProjectViewModel {
        /// <summary>
        /// </summary>
        public JiraProjectDesignViewModel() {
        }

        /// <summary>
        /// </summary>
        /// <param name="key"></param>
        /// <param name="name"></param>
        public JiraProjectDesignViewModel(string key, string name) {
            Key = key;
            Name = name;
        }

        /// <summary>
        ///     Liefert den Schlüssel des Projekts
        /// </summary>
        public string Key { get; } = "PROJECT42";

        /// <summary>
        ///     Liefert den Namen des Projekts
        /// </summary>
        public string Name { get; } = "Projekt 42";

        /// <summary>
        ///     Liefert das Projekt
        /// </summary>
        public Project Project { get; }
    }
}