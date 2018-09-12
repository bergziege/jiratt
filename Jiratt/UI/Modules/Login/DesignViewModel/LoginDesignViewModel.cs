using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.Login.DesignViewModel {
    /// <summary>
    ///     Diesngn View Model einer Login View
    /// </summary>
    public class LoginDesignViewModel : ILoginViewModel {
        /// <summary>
        ///     Liefert ein Login Command, von dem eigentlich nur die CanExecute Methode verwendet wird. Das eigentliche Login bzw.
        ///     Erzeugen des Jira CLients erfolgt im Code behind um nicht das "klartext" Passwort unnötig duch die Gegend zu
        ///     schieben.
        /// </summary>
        public DelegateCommand FakeLoginCommand { get; }

        /// <summary>
        ///     Setzt ob in der UI ein Passwort eingegeben wurde
        /// </summary>
        public bool IsPasswordSet { get; set; } = true;

        /// <summary>
        ///     Liefert oder setzt die Server URL
        /// </summary>
        public string ServerUrl { get; set; } = "https://google.de";

        /// <summary>
        ///     Liefert oder setzt den Nutzernamen
        /// </summary>
        public string Username { get; set; } = "mustermann";

        /// <summary>
        ///     Registriert einen Jira Client am Container
        /// </summary>
        /// <param name="jiraClient"></param>
        public void RegisterJiraClient(Jira jiraClient) {
        }
    }
}