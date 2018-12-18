using Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch.ViewCommands;
using Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch {
    /// <summary>
    ///     MOdul für die Suche und Vorgangsauswahl
    /// </summary>
    public class TaskSearchModule{

        public static void OnInitialized(IContainerProvider containerProvider, IRegionManager regionManager) {
        }

        /// <summary>
        /// </summary>
        public static void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<TaskSearchView>();
            containerRegistry.Register<ITaskSearchViewModel, TaskSearchViewModel>();
            containerRegistry.Register<TaskSearchViewCommand>();

            ViewModelLocationProvider.Register<TaskSearchView, ITaskSearchViewModel>();
        }
    }
}