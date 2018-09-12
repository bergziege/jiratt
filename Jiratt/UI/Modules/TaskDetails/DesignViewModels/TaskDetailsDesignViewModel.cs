using Jiratt.UI.Modules.TaskDetails.IssueTabItem;
using Jiratt.UI.Modules.TaskDetails.IssueTabItem.DesignViewModels;

namespace Jiratt.UI.Modules.TaskDetails.DesignViewModels {
    /// <summary>
    ///     Design View Model einer Ansicht zur Vorgangs Detailansicht
    /// </summary>
    public class TaskDetailsDesignViewModel : ITaskDetailsViewModel {
        /// <summary>
        ///     Liefert das View Model aus dem alten Jira integrierten Ansicht zur Vorgangsdetailanzeige
        /// </summary>
        public IIssueTabItemViewModel IssueTabItemViewModel { get; } = new IssueTabItemDesignViewModel();
    }
}