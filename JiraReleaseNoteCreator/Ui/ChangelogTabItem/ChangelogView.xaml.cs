using System.Linq;
using System.Windows.Controls;

using Atlassian.Jira;

namespace JiraReleaseNoteCreator.Ui.ChangelogTabItem {
    /// <summary>
    /// Interaktionslogik für ChangelogView.xaml
    /// </summary>
    public partial class ChangelogView : UserControl {
        public ChangelogView() {
            InitializeComponent();
        }

        private void Selector_OnSelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (DataContext is IChangelogTabItemViewModel) {
                IChangelogTabItemViewModel vm = (IChangelogTabItemViewModel)DataContext;
                vm.SelectedProjectVersions = ((ListView)sender).SelectedItems.Cast<ProjectVersion>().ToList();
            }
        }
    }
}
