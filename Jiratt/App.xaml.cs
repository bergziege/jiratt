using System.Windows;
using Jiratt.UI.Modules.Login.ViewCommands;
using Microsoft.Practices.Unity;

namespace Jiratt {
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        /// <summary>
        ///     Wenn die Anwendung gestartet wird ...
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            Bootstrapper bootstrapper = new Bootstrapper();
            bootstrapper.Run();

            LoginViewCommand loginViewCommand = bootstrapper.Container.Resolve<LoginViewCommand>();
            loginViewCommand.Execute();
        }
    }
}