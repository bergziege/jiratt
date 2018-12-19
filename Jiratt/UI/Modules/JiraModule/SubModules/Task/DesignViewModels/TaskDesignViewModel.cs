using System;
using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task.DesignViewModels {
    /// <summary>
    ///     Design View Model für die Darstellung eines einzelnen Tasks
    /// </summary>
    public class TaskDesignViewModel : ITaskViewModel {
        /// <summary>
        ///     Liefert ein Command um die Zeit zu verwerfen
        /// </summary>
        public DelegateCommand DiscardTimeCommand { get; } = new DelegateCommand(() => { });

        /// <summary>
        ///     Liefert den Task
        /// </summary>
        public Issue Issue { get; } = null;

        /// <summary>
        ///     Speichert die Zeit und setzt sie zurück
        /// </summary>
        public DelegateCommand SaveTimeCommand { get; } = new DelegateCommand(() => { });

        /// <summary>
        ///     Startet die Zeit
        /// </summary>
        public DelegateCommand StartTimeCommand { get; } = new DelegateCommand(() => { });

        /// <summary>
        ///     Stoppt die Zeit
        /// </summary>
        public DelegateCommand StopTimeCommand { get; } = new DelegateCommand(() => { });

        /// <summary>
        ///     Liefert die noch nicht gespeicherte Zeit
        /// </summary>
        public TimeSpan TimeNotLogged { get; } = new TimeSpan(0, 2, 3, 5);
    }
}