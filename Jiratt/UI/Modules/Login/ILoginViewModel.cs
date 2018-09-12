using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.Login {
    /// <summary>
    ///     Schnittstelle für View Models für eine Loginansicht
    /// </summary>
    public interface ILoginViewModel {
        /// <summary>
        ///     Liefert ein Login Command, von dem eigentlich nur die CanExecute Methode verwendet wird. Das eigentliche Login bzw.
        ///     Erzeugen des Jira CLients erfolgt im Code behind um nicht das "klartext" Passwort unnötig duch die Gegend zu
        ///     schieben.
        /// </summary>
        DelegateCommand FakeLoginCommand { get; }

        /// <summary>
        ///     Setzt ob in der UI ein Passwort eingegeben wurde
        /// </summary>
        bool IsPasswordSet { set; }

        /// <summary>
        ///     Liefert oder setzt die Server URL
        /// </summary>
        string ServerUrl { get; set; }

        /// <summary>
        ///     Liefert oder setzt den Nutzernamen
        /// </summary>
        string Username { get; set; }

        /// <summary>
        ///     Registriert einen Jira Client am Container
        /// </summary>
        /// <param name="jiraClient"></param>
        void RegisterJiraClient(Jira jiraClient);
    }
}