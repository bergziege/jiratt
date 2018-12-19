using System;
using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task.DesignViewModels {
    public class TaskDesignViewModel : ITaskViewModel {
        private Issue _issue;
        private DelegateCommand _startTimeCommand;
        private DelegateCommand _stopTimeCommand;

        public DelegateCommand DiscardTimeCommand { get; }

        public Issue Issue {
            get { return _issue; }
        }

        public DelegateCommand SaveTimeCommand { get; }

        public DelegateCommand StartTimeCommand {
            get { return _startTimeCommand; }
        }

        public DelegateCommand StopTimeCommand {
            get { return _stopTimeCommand; }
        }

        public TimeSpan TimeNotLogged { get; } = new TimeSpan(0, 2, 3, 5);
    }
}