using System.Threading;
using System.Windows;
using Jiratt.Services.Services;
using Jiratt.Services.Services.Impl;
using Jiratt.Services.Worker;
using Jiratt.UI.Modules.JiraModule;
using Jiratt.UI.Modules.StartStopModule;
using Jiratt.UI.Shell;
using Prism.Ioc;
using Prism.Modularity;

namespace Jiratt {
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App {
        /// <summary>
        ///     Configures the <see cref="T:Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog) {
            base.ConfigureModuleCatalog(moduleCatalog);

            moduleCatalog.AddModule<JiraModule>();
            moduleCatalog.AddModule<StartStopModule>();
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
            containerRegistry.Register<ITimeSpanService, TimeSpanService>();
            containerRegistry.Register<IWorklogService, WorklogService>();

            Thread workerThread = new Thread(
                () => {
                    containerRegistry.RegisterSingleton<GlobalTimer>();

                    /* TTW einmalig auflösen, damit dieser initialisiert wird. */
                    Container.Resolve<GlobalTimer>();
                });
            workerThread.Start();
        }
    }
}