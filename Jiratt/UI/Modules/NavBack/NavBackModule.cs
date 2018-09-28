using System.Windows.Input;
using Jiratt.UI.Modules.Login;
using Jiratt.UI.Modules.Login.ViewCommands;
using Jiratt.UI.Modules.Login.ViewModels;
using Jiratt.UI.Modules.NavBack.ViewModels;
using Jiratt.UI.Shell;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace Jiratt.UI.Modules.NavBack {
    public class NavBackModule : IModule {
        private IRegionManager _regionManager;
        private IUnityContainer _unityContainer;

        public NavBackModule(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }

        public void Initialize() {
            RegisterTypes();
            _regionManager.RequestNavigate(ShellRegionNames.LeftStatusBarRegion, nameof(NavBackView));
        }

        private void RegisterTypes()
        {
            _unityContainer.RegisterTypeForNavigation<NavBackView>();
            _unityContainer.RegisterType<INavBackViewModel, NavBackViewModel>();

            ViewModelLocationProvider.Register<NavBackView, INavBackViewModel>();
        }
    }
}