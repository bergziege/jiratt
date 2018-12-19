using Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewCommands;
using Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewModels;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task {
    /// <summary>
    ///     Jira Submodule für einen einzelnen Task
    /// </summary>
    public class TaskModule {
        /// <summary>
        ///     Kann vom Elternmodul aufgerufen werden, wenn es initialisiert ist.
        /// </summary>
        /// <param name="containerProvider"></param>
        /// <param name="regionManager"></param>
        public static void OnInitialized(IContainerProvider containerProvider, IRegionManager regionManager) {
        }

        /// <summary>
        ///     Kann vom Elternmodul aufgerufen werden um weitere Typen zu registrieren
        /// </summary>
        public static void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<TaskView>();
            containerRegistry.Register<ITaskViewModel, TaskViewModel>();
            containerRegistry.Register<ShowTaskDetailsViewCommand>();

            ViewModelLocationProvider.Register<TaskView, ITaskViewModel>();
        }
    }
}