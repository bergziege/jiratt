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
using JiraReleaseNoteCreator.Ui.TimeTracking.DesignViewModels;
using JiraReleaseNoteCreator.Ui.TimeTracking.ViewModels;
using Microsoft.Practices.Unity;

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

            InitContainerAndAppContext();
            RegisterViewModels();
            RegisterViews();

            Ui.MainView.MainWindow window = AppContext.Instance.Container.Resolve<Ui.MainView.MainWindow>();
            IMainViewModel vm = AppContext.Instance.Container.Resolve<IMainViewModel>();
            window.DataContext = vm;
            MainWindow = window;
            MainWindow.Show();
        }

        private void RegisterViews() {
            AppContext.Instance.Container.RegisterType<MainWindow>();
        }

        private void RegisterViewModels() {
            AppContext.Instance.Container.RegisterType<IMainViewModel,MainViewModel>();
            AppContext.Instance.Container.RegisterType<ITimeTrackingViewModel, TimeTrackingViewModel>();
            AppContext.Instance.Container.RegisterType<ITabItemViewModel, TabItemViewModel>();
            AppContext.Instance.Container.RegisterType<IChangelogTabItemViewModel, ChangelogTabItemViewModel>();
            AppContext.Instance.Container.RegisterType<IIssueTabItemViewModel, IssueTabItemViewModel>();
            AppContext.Instance.Container.RegisterType<ICommitCommentViewModel, CommitCommentViewModel>();

        }

        private static void InitContainerAndAppContext() {
            IUnityContainer container = new UnityContainer();
            AppContext.Instance.Container = container;
        }
    }
}