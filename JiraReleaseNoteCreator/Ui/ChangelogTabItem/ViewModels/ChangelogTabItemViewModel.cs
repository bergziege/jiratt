using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Atlassian.Jira;

using JiraReleaseNoteCreator.ChangelogModel;
using Prism.Mvvm;

namespace JiraReleaseNoteCreator.Ui.ChangelogTabItem.ViewModels {
    public class ChangelogTabItemViewModel: BindableBase, IChangelogTabItemViewModel {
        private string _changelog;
        private ObservableCollection<ProjectVersion> _projectVersions = new ObservableCollection<ProjectVersion>();
        private Jira _jira;
        private IList<ProjectVersion> _selectedProjectVersion;
        private Project _project;

        public ChangelogTabItemViewModel(Jira jira) {
            _jira = jira;
        }

        public string Changelog {
            get { return _changelog; }
            private set {
                _changelog = value;
                RaisePropertyChanged(nameof(Changelog));
            }
        }
        public ObservableCollection<ProjectVersion> ProjectVersions {
            get { return _projectVersions; }
            set { _projectVersions = value; }
        }

        private void ListChangesInVersions(IList<ProjectVersion> versions) {
            if (versions == null) {
                Changelog = string.Empty;
                return;
            }

            ChangelogModel.ChangelogModel changelogModel = new ChangelogModel.ChangelogModel();

            foreach (ProjectVersion version in versions) {
                List<Issue> issuesInVersion =
                        _jira.GetIssuesFromJql("project = " + _project.Key + " AND fixVersion = '" + version.Name + "'").ToList();
                VersionModel versionModel = new VersionModel();
                versionModel.Version = version.Name;
                foreach (Issue issue in issuesInVersion) {
                    if (!issue.Type.IsSubTask) {
                        IssueTypeModel typeModelForIssue = versionModel.IssueTypes.FirstOrDefault(x => x.IssueType.Id == issue.Type.Id);
                        if (typeModelForIssue == null) {
                            IssueTypeModel typeModel = new IssueTypeModel();
                            typeModel.IssueType = issue.Type;
                            versionModel.IssueTypes.Add(typeModel);
                            typeModelForIssue = typeModel;
                        }

                        typeModelForIssue.Issues.Add(new IssueModel() { Issue = issue });
                    } else {
                    }
                }
                changelogModel.Versions.Add(versionModel);
            }

            Changelog = changelogModel.ToString();
        }



        private void ListVersionsForProject() {
            ProjectVersions.Clear();
            foreach (ProjectVersion projectVersion in _jira.GetProjectVersions(_project.Key)) {
                ProjectVersions.Add(projectVersion);
            }
        }

        public IList<ProjectVersion> SelectedProjectVersions {
            get { return _selectedProjectVersion; }
            set {
                _selectedProjectVersion = value;
                RaisePropertyChanged(nameof(SelectedProjectVersions));
                ListChangesInVersions(value);
            }
        }

        public void LoadData(Project project) {
            if (project == null) {
                throw new ArgumentNullException("project");
            }
            _project = project;
            ListVersionsForProject();
        }
    }
}