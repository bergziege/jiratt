using Jiratt.UI.Modules.Login.ViewCommands;
using Jiratt.UI.Modules.Login.ViewModels;
using Jiratt.UI.Shell;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.Login {
    /// <summary>
    ///     Modul für Logincunktionalität
    /// </summary>
    public class LoginModule : IModule {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="unityContainer"></param>
        public LoginModule(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>Notifies the module that it has be initialized.</summary>
        public void OnInitialized(IContainerProvider containerProvider) {
            _regionManager.RegisterViewWithRegion(ShellRegionNames.RightContentRegion, typeof(Login));
        }

        /// <summary>
        /// </summary>
        public void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<Login>();
            containerRegistry.Register<ILoginViewModel, LoginViewModel>();
            containerRegistry.Register<LoginViewCommand>();

            ViewModelLocationProvider.Register<Login, ILoginViewModel>();
        }
    }
}