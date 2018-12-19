using System;
using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task {
    public interface ITaskViewModel {
        DelegateCommand DiscardTimeCommand { get; }
        Issue Issue { get; }
        DelegateCommand SaveTimeCommand { get; }
        DelegateCommand StartTimeCommand { get; }
        DelegateCommand StopTimeCommand { get; }
        TimeSpan TimeNotLogged { get; }
    }
}