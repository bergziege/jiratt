using System;
using Atlassian.Jira;
using Prism.Commands;

namespace Jiratt.UI.Modules.JiraModule.SubModules.Task {
    /// <summary>
    ///     Schnittstelle für View Models für ein einzelnen Jira Task
    /// </summary>
    public interface ITaskViewModel {
        /// <summary>
        ///     Liefert ein Command um die Zeit zu verwerfen
        /// </summary>
        DelegateCommand DiscardTimeCommand { get; }

        /// <summary>
        ///     Liefert den Task
        /// </summary>
        Issue Issue { get; }

        /// <summary>
        ///     Speichert die Zeit und setzt sie zurück
        /// </summary>
        DelegateCommand SaveTimeCommand { get; }

        /// <summary>
        ///     Startet die Zeit
        /// </summary>
        DelegateCommand StartTimeCommand { get; }

        /// <summary>
        ///     Stoppt die Zeit
        /// </summary>
        DelegateCommand StopTimeCommand { get; }

        /// <summary>
        ///     Liefert die noch nicht gespeicherte Zeit
        /// </summary>
        TimeSpan TimeNotLogged { get; }
    }
}