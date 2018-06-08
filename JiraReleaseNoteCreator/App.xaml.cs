using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using JiraReleaseNoteCreator.Ui.ChangelogTabItem;
using JiraReleaseNoteCreator.Ui.ChangelogTabItem.ViewModels;
using JiraReleaseNoteCreator.Ui.CommitComment;
using JiraReleaseNoteCreator.Ui.CommitComment.ViewModels;
using JiraReleaseNoteCreator.Ui.IssueTabItem;
using JiraReleaseNoteCreator.Ui.IssueTabItem.ViewModels;
using JiraReleaseNoteCreator.Ui.MainView;
using JiraReleaseNoteCreator.Ui.MainView.ViewModels;
using JiraReleaseNoteCreator.Ui.TabItem;
using JiraReleaseNoteCreator.Ui.TabItem.ViewModels;
using JiraReleaseNoteCreator.Ui.TimeTracking;
using JiraReleaseNoteCreator.Ui.TimeTracking.ViewModels;
using Microsoft.Practices.Unity;
using Squirrel;

namespace JiraReleaseNoteCreator {
    /// <summary>
    ///     Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application {
        /// <summary>
        ///     Löst das <see cref="E:System.Windows.Application.Startup" />-Ereignis aus.
        /// </summary>
        /// <param name="e">Ein <see cref="T:System.Windows.StartupEventArgs" />, das die Ereignisdaten enthält.</param>
        protected override void OnStartup(StartupEventArgs e) {
            IUnityContainer container = InitContainerAndAppContext();
            RegisterViewModels(container);
            RegisterViews(container);

            MainWindow window = container.Resolve<MainWindow>();
            IMainViewModel vm = container.Resolve<IMainViewModel>();
            window.DataContext = vm;
            MainWindow = window;
            MainWindow.Show();

            Task.Run(
                () => { Update(); });
        }

        private static IUnityContainer InitContainerAndAppContext() {
            return new UnityContainer();
        }

        private void RegisterViewModels(IUnityContainer container) {
            container.RegisterType<IMainViewModel, MainViewModel>();
            container.RegisterType<ITimeTrackingViewModel, TimeTrackingViewModel>();
            container.RegisterType<ITabItemViewModel, TabItemViewModel>();
            container.RegisterType<IChangelogTabItemViewModel, ChangelogTabItemViewModel>();
            container.RegisterType<IIssueTabItemViewModel, IssueTabItemViewModel>();
            container.RegisterType<ICommitCommentViewModel, CommitCommentViewModel>();
        }

        private void RegisterViews(IUnityContainer container) {
            container.RegisterType<MainWindow>();
        }

        private async void Update() {
            using (var mgr = new UpdateManager("http://www.berndnet-2000.de/Releases/jiratt")) {
                try {
                    await mgr.UpdateApp();
                } catch (Exception ex) {
                    Debug.WriteLine(ex.Message);
                }
            }
        }
    }
}