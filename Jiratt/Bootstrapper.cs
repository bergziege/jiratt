using System;
using System.Windows;
using Jiratt.UI.Modules.Login;
using Jiratt.UI.Modules.TaskSearch;
using Jiratt.UI.Shell;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Unity;

namespace Jiratt {
    public class Bootstrapper : UnityBootstrapper {
        protected override void ConfigureContainer() {
            base.ConfigureContainer();
            RegisterSingletonIfMissing<Shell>();
        }

        protected override void ConfigureModuleCatalog() {
            base.ConfigureModuleCatalog();
            AddModule<LoginModule>();
            AddModule<TaskSearchModule>();
        }

        protected override void ConfigureViewModelLocator() {
            base.ConfigureViewModelLocator();
        }

        protected override DependencyObject CreateShell() {
            return Container.TryResolve<Shell>();
        }

        protected override void InitializeShell() {
            base.InitializeShell();

            Application.Current.MainWindow = (Window)Shell;
            Application.Current.MainWindow.Show();
        }

        private void RegisterSingletonIfMissing<TType>() {
            RegisterTypeIfMissing(typeof(TType), typeof(TType), true);
        }
 
        private void RegisterTypeIfMissing<TInterface, TType>() {
            RegisterTypeIfMissing(typeof(TInterface), typeof(TType), false);
        }

        private void AddModule<T>()
        {
            Type moduleType = typeof(T);
            ModuleCatalog.AddModule(new ModuleInfo(moduleType.Name, moduleType.AssemblyQualifiedName));
        }
    }
}