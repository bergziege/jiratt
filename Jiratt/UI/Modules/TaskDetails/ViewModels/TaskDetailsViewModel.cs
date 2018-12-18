using Jiratt.UI.Modules.TaskDetails.IssueTabItem;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.TaskDetails.ViewModels {
    /// <summary>
    ///     View Model einer Vorgangsdetailansicht
    /// </summary>
    public class TaskDetailsViewModel : BindableBase, INavigationAware, ITaskDetailsViewModel {
        private IIssueTabItemViewModel _issueTabItemViewModel;

        /// <summary>
        /// </summary>
        /// <param name="issueTabItemViewModel"></param>
        public TaskDetailsViewModel(IIssueTabItemViewModel issueTabItemViewModel) {
            IssueTabItemViewModel = issueTabItemViewModel;
        }

        /// <summary>
        ///     Liefert das View Model aus dem alten Jira integrierten Ansicht zur Vorgangsdetailanzeige
        /// </summary>
        public IIssueTabItemViewModel IssueTabItemViewModel {
            get { return _issueTabItemViewModel; }
            private set { SetProperty(ref _issueTabItemViewModel, value); }
        }

        public void OnNavigatedTo(NavigationContext navigationContext) {
            //ShowTaskDetailsViewCommandParameters showTaskDetailsViewCommandParameters = navigationContext.Parameters["params"] as ShowTaskDetailsViewCommandParameters;
            //IssueTabItemViewModel.LoadData(showTaskDetailsViewCommandParameters.IssueKey);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext) {
            
        }
    }
}