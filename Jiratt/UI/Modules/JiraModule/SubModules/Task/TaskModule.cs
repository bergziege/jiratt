using Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewCommands;
using Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task {
    public class TaskModule {
        public static void OnInitialized(IContainerProvider containerProvider, IRegionManager regionManager)
        {
        }

        /// <summary>
        /// </summary>
        public static void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<TaskView>();
            containerRegistry.Register<ITaskViewModel, TaskViewModel>();
            containerRegistry.Register<ShowTaskDetailsViewCommand>();

            ViewModelLocationProvider.Register<TaskView, ITaskViewModel>();
        }
    }
}