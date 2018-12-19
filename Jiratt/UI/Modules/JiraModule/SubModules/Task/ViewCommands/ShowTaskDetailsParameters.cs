using Atlassian.Jira;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task.ViewCommands {
    public class ShowTaskDetailsParameters {
        public const string PARAM_KEY = "{6F7AD822-BDFC-4921-B639-F88B745C0958}";

        public ShowTaskDetailsParameters(Issue issue) {
            Issue = issue;
        }

        public Issue Issue { get; }
    }
}