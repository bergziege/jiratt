using Atlassian.Jira;
using Jiratt.UI.Modules.TaskSearch.ViewCommands;
using Microsoft.Practices.Unity;
using Prism.Commands;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.Login.ViewModels {
    /// <summary>
    ///     View Model einer Login View
    /// </summary>
    public class LoginViewModel : BindableBase, ILoginViewModel {
        private readonly IUnityContainer _container;
        private readonly TaskSearchViewCommand _taskSearchViewCommand;
        private DelegateCommand _fakeLoginCommand;
        private bool _isPasswordSet;
        private string _serverUrl;
        private string _username;

        /// <summary>
        /// </summary>
        /// <param name="container"></param>
        /// <param name="taskSearchViewCommand"></param>
        public LoginViewModel(IUnityContainer container, TaskSearchViewCommand taskSearchViewCommand) {
            _container = container;
            _taskSearchViewCommand = taskSearchViewCommand;
        }

        /// <summary>
        ///     Liefert ein Login Command, von dem eigentlich nur die CanExecute Methode verwendet wird. Das eigentliche Login bzw.
        ///     Erzeugen des Jira CLients erfolgt im Code behind um nicht das "klartext" Passwort unnötig duch die Gegend zu
        ///     schieben.
        /// </summary>
        public DelegateCommand FakeLoginCommand {
            get {
                if (_fakeLoginCommand == null) {
                    _fakeLoginCommand = new DelegateCommand(DoFakeLogin, CanDoLogin);
                }

                return _fakeLoginCommand;
            }
        }

        /// <summary>
        ///     Setzt ob in der UI ein Passwort eingegeben wurde
        /// </summary>
        public bool IsPasswordSet {
            private get { return _isPasswordSet; }
            set {
                SetProperty(ref _isPasswordSet, value);
                FakeLoginCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        ///     Liefert oder setzt die Server URL
        /// </summary>
        public string ServerUrl {
            get { return _serverUrl; }
            set {
                SetProperty(ref _serverUrl, value);
                FakeLoginCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        ///     Liefert oder setzt den Nutzernamen
        /// </summary>
        public string Username {
            get { return _username; }
            set {
                SetProperty(ref _username, value);
                FakeLoginCommand.RaiseCanExecuteChanged();
            }
        }

        /// <summary>
        ///     Registriert einen Jira Client am Container
        /// </summary>
        /// <param name="jiraClient"></param>
        public void RegisterJiraClient(Jira jiraClient) {
            _container.RegisterInstance(jiraClient);
            _taskSearchViewCommand.Execute();
        }

        private bool CanDoLogin() {
            return !string.IsNullOrWhiteSpace(ServerUrl) && !string.IsNullOrWhiteSpace(Username) && IsPasswordSet;
        }

        private void DoFakeLogin() {
            /* Nix tun. Login wird im Code behind durchgeführt und der Jira Client anschließend im Container registriert. */
        }
    }
}