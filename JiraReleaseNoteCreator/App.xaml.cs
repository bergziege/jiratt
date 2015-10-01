using System.Windows;

using DryIoc;

using JiraReleaseNoteCreator.Ui.ChangelogTabItem;
using JiraReleaseNoteCreator.Ui.ChangelogTabItem.ViewModels;
using JiraReleaseNoteCreator.Ui.CommitComment;
using JiraReleaseNoteCreator.Ui.CommitComment.ViewModels;
using JiraReleaseNoteCreator.Ui.IssueTabItem;
using JiraReleaseNoteCreator.Ui.IssueTabItem.ViewModels;
using JiraReleaseNoteCreator.Ui.MainView.ViewModels;
using JiraReleaseNoteCreator.Ui.TabItem;
using JiraReleaseNoteCreator.Ui.TabItem.ViewModels;
using JiraReleaseNoteCreator.Ui.TimeTracking;
using JiraReleaseNoteCreator.Ui.TimeTracking.DesignViewModels;
using JiraReleaseNoteCreator.Ui.TimeTracking.ViewModels;

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
            MainViewModel vm = AppContext.Instance.Container.Resolve<MainViewModel>();
            window.DataContext = vm;
            MainWindow = window;
            MainWindow.Show();
        }

        private void RegisterViews() {
            AppContext.Instance.Container.Register<Ui.MainView.MainWindow>();
        }

        private void RegisterViewModels() {
            AppContext.Instance.Container.Register<MainViewModel>();
            AppContext.Instance.Container.Register<ITimeTrackingViewModel, TimeTrackingViewModel>();
            AppContext.Instance.Container.Register<ITabItemViewModel, TabItemViewModel>();
            AppContext.Instance.Container.Register<IChangelogTabItemViewModel, ChangelogTabItemViewModel>();
            AppContext.Instance.Container.Register<IIssueTabItemViewModel, IssueTabItemViewModel>();
            AppContext.Instance.Container.Register<ICommitCommentViewModel, CommitCommentViewModel>();

        }

        private static void InitContainerAndAppContext() {
            IContainer container = new Container();
            AppContext.Instance.Container = container;
        }
    }
}