using Jiratt.UI.Modules.JiraModule.SubModules.CommitComment;
using Jiratt.UI.Modules.JiraModule.SubModules.CommitComment.ViewModels;
using Jiratt.UI.Modules.StartStopModule.ViewModels;
using Jiratt.UI.Shell;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.StartStopModule {
    /// <summary>
    ///     Modul für die Detailansicht eines Vorgangs
    /// </summary>
    public class StartStopModule : IModule {
        private readonly IRegionManager _regionManager;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        public StartStopModule(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>Notifies the module that it has be initialized.</summary>
        public void OnInitialized(IContainerProvider containerProvider) {
            _regionManager.RegisterViewWithRegion(ShellRegionNames.TopStatusRegion, typeof(TimeTrackingView));
        }

        /// <summary>
        /// </summary>
        public void RegisterTypes(IContainerRegistry containerRegistry) {
            containerRegistry.Register<ITimeTrackingViewModel, TimeTrackingViewModel>();
            containerRegistry.Register<ICommitCommentViewModel, CommitCommentViewModel>();

            ViewModelLocationProvider.Register<TimeTrackingView, ITimeTrackingViewModel>();
        }
    }
}