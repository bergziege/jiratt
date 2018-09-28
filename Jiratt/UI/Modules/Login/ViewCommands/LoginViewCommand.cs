using System.Windows.Input;
using Jiratt.UI.Shell;
using Prism.Regions;

namespace Jiratt.UI.Modules.Login.ViewCommands {
    /// <summary>
    ///     View Command um das Login anzuzeigen
    /// </summary>
    public class LoginViewCommand {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        public LoginViewCommand(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>
        ///     Navigiert zur Login Ansicht
        /// </summary>
        public void Execute() {
            _regionManager.RequestNavigate(ShellRegionNames.MainRegion, nameof(Login));
        }
    }
}