using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.Login.DesignViewModel {
    /// <summary>
    ///     Diesngn View Model einer Login View
    /// </summary>
    public class LoginDesignViewModel : ILoginViewModel {
        /// <summary>
        ///     Liefert oder setzt den Fehlertext
        /// </summary>
        public string ErrorText { get; set; } =
            "öoysdf glidfbv iueypbgv iushbuvt lhuivhgs hgilövnhgzwsertp87v63wnß0tvil7zteirnthveirhg vesrg vlersgt i whgglerouihrtiulvh84 hgiehbrug 3p845gw4stlibghliw4nbvg hrtsnbgliuhei vn ljsreblivhö6ibluhgfpnrtzijhiuhgoisrjthöoisökjgnwphg iöuwaulwbvnbtign v linbvlkfilnrjksgnbreil tgi aihiqluerhn giluwvjbdfvk ndyjkhvjsdhb jshdbvc ukz awulgf l3fvzutawg fliörbluzvw<zutk";

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