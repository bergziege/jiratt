using Jiratt.UI.Modules.TaskSearch.ViewCommands;
using Jiratt.UI.Modules.TaskSearch.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace Jiratt.UI.Modules.TaskSearch {
    /// <summary>
    ///     MOdul für die Suche und Vorgangsauswahl
    /// </summary>
    public class TaskSearchModule : IModule {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="unityContainer"></param>
        public TaskSearchModule(IRegionManager regionManager, IUnityContainer unityContainer) {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }

        /// <summary>Notifies the module that it has be initialized.</summary>
        public void Initialize() {
            RegisterTypes();
        }

        /// <summary>
        /// </summary>
        private void RegisterTypes() {
            _unityContainer.RegisterTypeForNavigation<TaskSearchView>();
            _unityContainer.RegisterType<ITaskSearchViewModel, TaskSearchViewModel>();
            _unityContainer.RegisterType<TaskSearchViewCommand>();

            ViewModelLocationProvider.Register<TaskSearchView, ITaskSearchViewModel>();
        }
    }
}