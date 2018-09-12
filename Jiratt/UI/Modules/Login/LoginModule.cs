using Jiratt.UI.Modules.Login.ViewCommands;
using Jiratt.UI.Modules.Login.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace Jiratt.UI.Modules.Login {
    /// <summary>
    ///     Modul für Logincunktionalität
    /// </summary>
    public class LoginModule : IModule {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="unityContainer"></param>
        public LoginModule(IRegionManager regionManager, IUnityContainer unityContainer) {
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
            _unityContainer.RegisterTypeForNavigation<Login>();
            _unityContainer.RegisterType<ILoginViewModel, LoginViewModel>();
            _unityContainer.RegisterType<LoginViewCommand>();

            ViewModelLocationProvider.Register<Login, ILoginViewModel>();
        }
    }
}