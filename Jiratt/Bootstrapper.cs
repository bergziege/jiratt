using System.Windows;
using Jiratt.UI.Shell;
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
    }
}