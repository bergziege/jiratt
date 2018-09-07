using Jiratt.UI.Modules.TaskSearch.ViewCommands;
using Jiratt.UI.Modules.TaskSearch.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace Jiratt.UI.Modules.TaskSearch {
    public class TaskSearchModule : IModule {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public TaskSearchModule(IRegionManager regionManager, IUnityContainer unityContainer) {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }

        public void Initialize() {
            RegisterTypes();
        }

        private void RegisterTypes() {
            _unityContainer.RegisterTypeForNavigation<TaskSearchView>();
            _unityContainer.RegisterType<ITaskSearchViewModel, TaskSearchViewModel>();
            _unityContainer.RegisterType<TaskSearchViewCommand>();

            ViewModelLocationProvider.Register<TaskSearchView, ITaskSearchViewModel>();
        }
    }
}