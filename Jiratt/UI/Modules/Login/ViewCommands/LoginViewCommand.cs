using Jiratt.UI.Shell;
using Prism.Regions;

namespace Jiratt.UI.Modules.Login.ViewCommands {
    public class LoginViewCommand {
        private readonly IRegionManager _regionManager;

        public LoginViewCommand(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        public void Execute() {
            _regionManager.RequestNavigate(ShellRegionNames.MainRegion, nameof(Login));
        }
    }
}