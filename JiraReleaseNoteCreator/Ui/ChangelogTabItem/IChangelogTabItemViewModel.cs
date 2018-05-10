using System.Collections.Generic;
using System.Collections.ObjectModel;

using Atlassian.Jira;

namespace JiraReleaseNoteCreator.Ui.ChangelogTabItem {
    public interface IChangelogTabItemViewModel {
         string Changelog { get; }

        ObservableCollection<ProjectVersion> ProjectVersions { get; set; }

        IList<ProjectVersion> SelectedProjectVersions { get; set; }

        void LoadData(Project project);
    }
}