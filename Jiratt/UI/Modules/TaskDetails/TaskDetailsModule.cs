using JiraReleaseNoteCreator.Ui.TimeTracking;
using JiraReleaseNoteCreator.Ui.TimeTracking.ViewModels;
using Jiratt.UI.Modules.TaskDetails.CommitComment;
using Jiratt.UI.Modules.TaskDetails.CommitComment.ViewModels;
using Jiratt.UI.Modules.TaskDetails.IssueTabItem;
using Jiratt.UI.Modules.TaskDetails.IssueTabItem.ViewModels;
using Jiratt.UI.Modules.TaskDetails.ViewModels;
using Jiratt.UI.Shell;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.TaskDetails {
    /// <summary>
    ///     Modul für die Detailansicht eines Vorgangs
    /// </summary>
    public class TaskDetailsModule : IModule {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        public TaskDetailsModule(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>Notifies the module that it has be initialized.</summary>
        public void OnInitialized(IContainerProvider containerProvider) {
            _regionManager.RegisterViewWithRegion(ShellRegionNames.CenterRegion, typeof(TaskDetailsView));
        }

        /// <summary>
        /// </summary>
        public void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.Register<ITaskDetailsViewModel, TaskDetailsViewModel>();
            containerRegistry.Register<IIssueTabItemViewModel, IssueTabItemViewModel>();
            containerRegistry.Register<ITimeTrackingViewModel, TimeTrackingViewModel>();
            containerRegistry.Register<ICommitCommentViewModel, CommitCommentViewModel>();

            ViewModelLocationProvider.Register<TaskDetailsView, ITaskDetailsViewModel>();
        }
    }
}