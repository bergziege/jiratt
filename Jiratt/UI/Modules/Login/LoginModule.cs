using Jiratt.UI.Modules.Login.ViewCommands;
using Jiratt.UI.Modules.Login.ViewModels;
using Jiratt.UI.Shell;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace Jiratt.UI.Modules.Login {
    public class LoginModule : IModule {
       
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        public LoginModule(IRegionManager regionManager, IUnityContainer unityContainer) {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }

        public void Initialize()
        {
            RegisterTypes();
        }
        
        private void RegisterTypes()
        {
            _unityContainer.RegisterTypeForNavigation<Login>();
            _unityContainer.RegisterType<ILoginViewModel, LoginViewModel>();
            _unityContainer.RegisterType<LoginViewCommand>();

            ViewModelLocationProvider.Register<Login, ILoginViewModel>();
        }
    }
}