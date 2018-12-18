using Jiratt.UI.Modules.TaskSearch.ViewCommands;
using Jiratt.UI.Modules.TaskSearch.ViewModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.TaskSearch {
    /// <summary>
    ///     MOdul für die Suche und Vorgangsauswahl
    /// </summary>
    public class TaskSearchModule : IModule {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="unityContainer"></param>
        public TaskSearchModule(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider) {
        }

        /// <summary>
        /// </summary>
        public void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<TaskSearchView>();
            containerRegistry.Register<ITaskSearchViewModel, TaskSearchViewModel>();
            containerRegistry.Register<TaskSearchViewCommand>();

            ViewModelLocationProvider.Register<TaskSearchView, ITaskSearchViewModel>();
        }
    }
}