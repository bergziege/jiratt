using Atlassian.Jira;
using Microsoft.Practices.Unity;

namespace Jiratt.UI.Modules.Login.ViewModels {
    public class LoginViewModel : ILoginViewModel {
        private readonly IUnityContainer _container;

        public LoginViewModel(IUnityContainer container) {
            _container = container;
        }

        public void RegisterJiraClient(Jira jiraClient) {
            _container.RegisterInstance(jiraClient);
        }
    }
}