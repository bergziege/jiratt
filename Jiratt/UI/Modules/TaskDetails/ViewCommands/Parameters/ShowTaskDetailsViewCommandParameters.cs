namespace Jiratt.UI.Modules.TaskDetails.ViewCommands.Parameters {
    /// <summary>
    ///     Parameter für ein Command zur Anzeige der Detailansicht.
    /// </summary>
    public class ShowTaskDetailsViewCommandParameters {
        /// <summary>
        /// </summary>
        /// <param name="issueKey"></param>
        public ShowTaskDetailsViewCommandParameters(string issueKey) {
            IssueKey = issueKey;
        }

        /// <summary>
        ///     Liefert den Issue Key
        /// </summary>
        public string IssueKey { get; }
    }
}