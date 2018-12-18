using System;
using Atlassian.Jira;
using Jiratt.Common;
using Jiratt.UI.Modules.JiraModule.SubModules.TaskSearch.ViewCommands;
using Prism.Ioc;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Login.ViewModels {
    /// <summary>
    ///     View Model einer Login View
    /// </summary>
    public class LoginViewModel : BindableBase, ILoginViewModel {
        private readonly IContainerRegistry _container;
        private readonly TaskSearchViewCommand _taskSearchViewCommand;
        private RelayCommand _fakeLoginCommand;
        private bool _isPasswordSet;
        private string _serverUrl;
        private string _username;
        private string _errorText;

        /// <summary>
        /// </summary>
        /// <param name="container"></param>
        /// <param name="taskSearchViewCommand"></param>
        public LoginViewModel(IContainerRegistry container, TaskSearchViewCommand taskSearchViewCommand) {
            _container = container;
            _taskSearchViewCommand = taskSearchViewCommand;
        }

        /// <summary>
        ///     Liefert oder setzt den Fehlertext
        /// </summary>
        public string ErrorText {
            get { return _errorText; }
            set { SetProperty(ref _errorText, value); }
        }

        /// <summary>
        ///     Liefert ein Login Command, von dem eigentlich nur die CanExecute Methode verwendet wird. Das eigentliche Login bzw.
        ///     Erzeugen des Jira CLients erfolgt im Code behind um nicht das "klartext" Passwort unnötig duch die Gegend zu
        ///     schieben.
        /// </summary>
        public RelayCommand FakeLoginCommand {
            get {
                if (_fakeLoginCommand == null) {
                    _fakeLoginCommand = new RelayCommand(DoFakeLogin, CanDoLogin);
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
            }
        }

        /// <summary>
        ///     Liefert oder setzt die Server URL
        /// </summary>
        public string ServerUrl {
            get { return _serverUrl; }
            set {
                SetProperty(ref _serverUrl, value);
            }
        }

        /// <summary>
        ///     Liefert oder setzt den Nutzernamen
        /// </summary>
        public string Username {
            get { return _username; }
            set {
                SetProperty(ref _username, value);
            }
        }

        /// <summary>
        ///     Registriert einen Jira Client am Container
        /// </summary>
        /// <param name="jiraClient"></param>
        public void RegisterJiraClient(Jira jiraClient) {
            try {
                jiraClient.Projects.GetProjectsAsync().GetAwaiter().GetResult();
            } catch (Exception ex) {
                throw new Exception("Fehler in Server URL, Nutzername oder Passwort." + ex.Message);
            }

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