using System.Security;
using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.Login {
    public interface ILoginViewModel {
        void RegisterJiraClient(Jira jiraClient);
    }
}