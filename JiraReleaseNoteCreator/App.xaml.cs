using System;
using System.Diagnostics;
using System.Linq;
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
            Update();

            IUnityContainer container = InitContainerAndAppContext();
            RegisterViewModels(container);
            RegisterViews(container);

            MainWindow window = container.Resolve<MainWindow>();
            IMainViewModel vm = container.Resolve<IMainViewModel>();
            window.DataContext = vm;
            MainWindow = window;
            MainWindow.Show();

            //Task.Run(
            //    () => { Update(); });
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
            // Check for Squirrel application update
            ReleaseEntry release = null;
            using (var mgr = new UpdateManager("http://www.berndnet-2000.de/Releases/jiratt"))
            {
                //
                UpdateInfo updateInfo = await mgr.CheckForUpdate();
                if (updateInfo.ReleasesToApply.Any()) // Check if we have any update
                {
                    System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
                    FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

                    string msg =    "New version available!" +
                                    "\n\nCurrent version: " + updateInfo.CurrentlyInstalledVersion.Version +
                                    "\nNew version: " + updateInfo.FutureReleaseEntry.Version +
                                    "\n\nUpdate application now?";
                    MessageBoxResult dialogResult = MessageBox.Show(msg, fvi.ProductName, MessageBoxButton.YesNo, MessageBoxImage.Question);
                    if (dialogResult == MessageBoxResult.Yes)
                    {
                        // Do the update
                        release = await mgr.UpdateApp();
                    }
                }
            }

            // Restart the app
            if (release!=null)
            {
                UpdateManager.RestartApp();
            }           


            //using (var mgr = new UpdateManager("")) {
            //    try {
            //        await mgr.UpdateApp();
            //    } catch (Exception ex) {
            //        Debug.WriteLine(ex.Message);
            //    }
            //}
        }
    }
}