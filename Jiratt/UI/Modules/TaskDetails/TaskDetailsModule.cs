using JiraReleaseNoteCreator.Ui.TimeTracking;
using JiraReleaseNoteCreator.Ui.TimeTracking.ViewModels;
using Jiratt.UI.Modules.TaskDetails.CommitComment;
using Jiratt.UI.Modules.TaskDetails.CommitComment.ViewModels;
using Jiratt.UI.Modules.TaskDetails.IssueTabItem;
using Jiratt.UI.Modules.TaskDetails.IssueTabItem.ViewModels;
using Jiratt.UI.Modules.TaskDetails.ViewCommands;
using Jiratt.UI.Modules.TaskDetails.ViewModels;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Unity;

namespace Jiratt.UI.Modules.TaskDetails {
    /// <summary>
    ///     Modul für die Detailansicht eines Vorgangs
    /// </summary>
    public class TaskDetailsModule : IModule {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer _unityContainer;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="unityContainer"></param>
        public TaskDetailsModule(IRegionManager regionManager, IUnityContainer unityContainer) {
            _regionManager = regionManager;
            _unityContainer = unityContainer;
        }

        /// <summary>Notifies the module that it has be initialized.</summary>
        public void Initialize() {
            RegisterTypes();
        }

        /// <summary>
        /// </summary>
        private void RegisterTypes() {
            _unityContainer.RegisterTypeForNavigation<TaskDetailsView>();
            _unityContainer.RegisterType<ITaskDetailsViewModel, TaskDetailsViewModel>();
            _unityContainer.RegisterType<IIssueTabItemViewModel, IssueTabItemViewModel>();
            _unityContainer.RegisterType<ITimeTrackingViewModel, TimeTrackingViewModel>();
            _unityContainer.RegisterType<ICommitCommentViewModel, CommitCommentViewModel>();
            _unityContainer.RegisterType<ShowTaskDetailsViewCommand>();

            ViewModelLocationProvider.Register<TaskDetailsView, ITaskDetailsViewModel>();
        }
    }
}