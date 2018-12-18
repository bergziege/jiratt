using System;
using System.Windows;
using Jiratt.UI.Modules.Login;
using Jiratt.UI.Modules.NavBack;
using Jiratt.UI.Modules.TaskDetails;
using Jiratt.UI.Modules.TaskSearch;
using Jiratt.UI.Shell;
using Prism.Modularity;
using Prism.Unity;

namespace Jiratt {
    /// <summary>
    ///     Prism Bootstrapper
    /// </summary>
    public class Bootstrapper : UnityBootstrapper {
        /// <summary>
        ///     Configures the <see cref="T:Microsoft.Practices.Unity.IUnityContainer" />. May be overwritten in a derived class to
        ///     add specific
        ///     type mappings required by the application.
        /// </summary>
        protected override void ConfigureContainer() {
            base.ConfigureContainer();
            RegisterSingletonIfMissing<Shell>();
        }

        /// <summary>
        ///     Configures the <see cref="T:Prism.Modularity.IModuleCatalog" /> used by Prism.
        /// </summary>
        protected override void ConfigureModuleCatalog() {
            base.ConfigureModuleCatalog();
            AddModule<LoginModule>();
            AddModule<TaskSearchModule>();
            AddModule<TaskDetailsModule>();
            //AddModule<NavBackModule>();
        }

        /// <summary>
        ///     Configures the <see cref="T:Prism.Mvvm.ViewModelLocator" /> used by Prism.
        /// </summary>
        protected override void ConfigureViewModelLocator() {
            base.ConfigureViewModelLocator();
        }

        /// <summary>Creates the shell or main window of the application.</summary>
        /// <returns>The shell of the application.</returns>
        /// <remarks>
        ///     If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
        ///     <see cref="T:Prism.Bootstrapper" /> will attach the default <see cref="T:Prism.Regions.IRegionManager" /> of
        ///     the application in its <see cref="F:Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
        ///     in order to be able to add regions by using the <see cref="F:Prism.Regions.RegionManager.RegionNameProperty" />
        ///     attached property from XAML.
        /// </remarks>
        protected override DependencyObject CreateShell() {
            return Container.TryResolve<Shell>();
        }

        /// <summary>Initializes the shell.</summary>
        protected override void InitializeShell() {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        private void AddModule<T>() {
            Type moduleType = typeof(T);
            ModuleCatalog.AddModule(new ModuleInfo(moduleType.Name, moduleType.AssemblyQualifiedName));
        }

        private void RegisterSingletonIfMissing<TType>() {
            RegisterTypeIfMissing(typeof(TType), typeof(TType), true);
        }

        private void RegisterTypeIfMissing<TInterface, TType>() {
            RegisterTypeIfMissing(typeof(TInterface), typeof(TType), false);
        }
    }
}