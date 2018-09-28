using System.Windows.Input;
using Jiratt.UI.Shell;
using Prism.Regions;

namespace Jiratt.UI.Modules.TaskSearch.ViewCommands {
    /// <summary>
    ///     Command für die Tasksuche
    /// </summary>
    public class TaskSearchViewCommand {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        public TaskSearchViewCommand(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>
        ///     Navigiert zur Tasksuche
        /// </summary>
        public void Execute() {
            _regionManager.RequestNavigate(ShellRegionNames.MainRegion, nameof(TaskSearchView));
        }
    }
}