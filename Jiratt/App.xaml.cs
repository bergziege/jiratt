using System.Threading;
using System.Windows;
using Jiratt.Services.Worker;
using Jiratt.UI.Modules.Login;
using Jiratt.UI.Modules.TaskDetails;
using Jiratt.UI.Modules.TaskSearch;
using Jiratt.UI.Shell;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;

namespace Jiratt {
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : PrismApplication {
        /// <summary>
        ///     Configures the <see cref="T:Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<LoginModule>();
            moduleCatalog.AddModule<TaskDetailsModule>();
            moduleCatalog.AddModule<TaskSearchModule>();
        }

        /// <summary>Creates the shell or main window of the application.</summary>
        /// <returns>The shell of the application.</returns>
        protected override Window CreateShell() {
            return Container.Resolve<Shell>();
        }

        /// <summary>
        ///     Used to register types with the container that will be used by your application.
        /// </summary>
        protected override void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.Register<Shell>();
            containerRegistry.RegisterInstance(containerRegistry);

            Thread workerThread = new Thread(
                () => {
                    containerRegistry.Register<TimeTrackerWorker>();

                    /* TTW einmalig auflösen, damit dieser initialisiert wird. */
                    Container.Resolve<TimeTrackerWorker>();
                });
            workerThread.Start();
        }
    }
}