using System.Windows;
using System.Windows.Controls;

using JiraReleaseNoteCreator.Ui.ChangelogTabItem;
using JiraReleaseNoteCreator.Ui.IssueTabItem;

namespace JiraReleaseNoteCreator.Ui.TabItem.TemplateSelector {
    public class TabItemTemplateSelector : DataTemplateSelector {
        public DataTemplate ChangelogTabItemDataTemplate { get; set; }

        public DataTemplate IssueTabItemDataTemplate { get; set; }

        /// <summary>
        ///     Gibt beim Überschreiben in einer abgeleiteten Klasse ein <see cref="T:System.Windows.DataTemplate" />-Objekt auf
        ///     der Grundlage einer benutzerdefinierten Logik zurück.
        /// </summary>
        /// <returns>
        ///     Gibt eine <see cref="T:System.Windows.DataTemplate" /> oder null zurück. Der Standardwert ist null.
        /// </returns>
        /// <param name="item">Das Datenobjekt, für das die Vorlage ausgewählt werden soll.</param>
        /// <param name="container">Das datengebundene Objekt.</param>
        public override DataTemplate SelectTemplate(object item, DependencyObject container) {
            if (item is IIssueTabItemViewModel) {
                return IssueTabItemDataTemplate;
            }
            if (item is IChangelogTabItemViewModel) {
                return ChangelogTabItemDataTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}