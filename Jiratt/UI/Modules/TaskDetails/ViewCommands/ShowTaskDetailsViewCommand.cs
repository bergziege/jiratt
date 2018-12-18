using System.Windows.Input;
using Atlassian.Jira;
using Jiratt.UI.Modules.TaskDetails.ViewCommands.Parameters;
using Jiratt.UI.Shell;
using Prism.Regions;

namespace Jiratt.UI.Modules.TaskDetails.ViewCommands {
    /// <summary>
    ///     View Commans um eine Vorgangs Detailansicht anzuzeigen
    /// </summary>
    public class ShowTaskDetailsViewCommand {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        public ShowTaskDetailsViewCommand(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>
        ///     Führt das Command aus
        /// </summary>
        /// <param name="issue"></param>
        public void Execute(Issue issue) {
            NavigationParameters navParams = new NavigationParameters();
            navParams.Add("params", new ShowTaskDetailsViewCommandParameters(issue.Key.ToString()));
            _regionManager.RequestNavigate(ShellRegionNames.CenterRegion, nameof(TaskDetailsView), navParams);
        }
    }
}