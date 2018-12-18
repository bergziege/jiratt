using Jiratt.UI.Modules.JiraModule.Shell;
using Jiratt.UI.Modules.JiraModule.SubModules.Login.ViewCommands;
using Jiratt.UI.Modules.JiraModule.SubModules.Login.ViewModels;
using Jiratt.UI.Shell;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Login {
    /// <summary>
    ///     Modul für Logincunktionalität
    /// </summary>
    public class LoginModule {

        /// <summary>Notifies the module that it has be initialized.</summary>
        public static void OnInitialized(IContainerProvider containerProvider, IRegionManager regionManager) {
            regionManager.RegisterViewWithRegion(JiraShellRegionNames.SearchRegion, typeof(LoginView));
        }

        /// <summary>
        /// </summary>
        public static void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.RegisterForNavigation<LoginView>();
            containerRegistry.Register<ILoginViewModel, LoginViewModel>();
            containerRegistry.Register<LoginViewCommand>();

            ViewModelLocationProvider.Register<LoginView, ILoginViewModel>();
        }
    }
}