using Jiratt.UI.Modules.JiraModule.Shell;
using Jiratt.UI.Modules.JiraModule.SubModules.Login;
using Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch;
using Jiratt.UI.Shell;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule {
    public class JiraModule : IModule {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regionManager"></param>
        public JiraModule(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>
        /// Used to register types with the container that will be used by your application.
        /// </summary>
        public void RegisterTypes(IContainerRegistry containerRegistry) {
            LoginModule.RegisterTypes(containerRegistry);
            TaskSearchModule.RegisterTypes(containerRegistry);
        }

        /// <summary>Notifies the module that it has be initialized.</summary>
        public void OnInitialized(IContainerProvider containerProvider) {
            _regionManager.RegisterViewWithRegion(ShellRegionNames.RightContentRegion, typeof(JiraModuleShell));

            LoginModule.OnInitialized(containerProvider, _regionManager);
            TaskSearchModule.OnInitialized(containerProvider, _regionManager);
        }
    }
}