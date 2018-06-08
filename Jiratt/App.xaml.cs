using System;
using System.Windows;

namespace Jiratt {
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);
 
            Bootstrapper bootstrapper;
            try {
                bootstrapper = new Bootstrapper();
                bootstrapper.Run();
            } catch (Exception exception) {
                throw;
            }
        }
    }
}