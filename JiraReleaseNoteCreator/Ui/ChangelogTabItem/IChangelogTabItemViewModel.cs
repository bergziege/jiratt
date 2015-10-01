using System.Collections.Generic;
using System.Collections.ObjectModel;

using Atlassian.Jira;

using Com.QueoFlow.Commons.MVVM.ViewModels;

namespace JiraReleaseNoteCreator.Ui.ChangelogTabItem {
    public interface IChangelogTabItemViewModel: IViewModelBase {
         string Changelog { get; }

        ObservableCollection<ProjectVersion> ProjectVersions { get; set; }

        IList<ProjectVersion> SelectedProjectVersions { get; set; }

        void LoadData(Project project);
    }
}