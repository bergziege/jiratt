using System.Collections.Generic;
using System.Collections.ObjectModel;

using Atlassian.Jira;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.ChangelogTabItem.DesignViewModels {
    public class ChangelogTabItemDesignViewModel : BindableBase, IChangelogTabItemViewModel {
        public ChangelogTabItemDesignViewModel() {
            Changelog = "changed ...";
            ProjectVersions = new ObservableCollection<ProjectVersion>();
        }

        public string Changelog { get; private set; }

        public ObservableCollection<ProjectVersion> ProjectVersions { get; set; }

        public IList<ProjectVersion> SelectedProjectVersions { get; set; }

        public void LoadData(Project project) {
        }
    }
}