using Atlassian.Jira;
using Jiratt.UI.Modules.JiraModule.Shell;
using Prism.Regions;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewCommands {
    public class ShowTaskDetailsViewCommand {
        private readonly IRegionManager _regionManager;

        public ShowTaskDetailsViewCommand(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        public void Execute(Issue issue) {
            NavigationParameters navParams = new NavigationParameters();
            navParams.Add(ShowTaskDetailsParameters.PARAM_KEY, new ShowTaskDetailsParameters(issue));
            _regionManager.RequestNavigate(JiraShellRegionNames.TrackingRegion, nameof(TaskView), navParams);
        }
    }
}