using Jiratt.UI.Modules.TaskDetails.IssueTabItem;

namespace Jiratt.UI.Modules.TaskDetails {
    /// <summary>
    ///     Schnittstelle für View Models für Ansichten für Vorgangsdetails
    /// </summary>
    public interface ITaskDetailsViewModel {
        /// <summary>
        ///     Liefert das View Model aus dem alten Jira integrierten Ansicht zur Vorgangsdetailanzeige
        /// </summary>
        IIssueTabItemViewModel IssueTabItemViewModel { get; }
    }
}