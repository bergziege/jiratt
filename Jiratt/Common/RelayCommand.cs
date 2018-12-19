using System;

using System.Diagnostics;
using System.Windows.Input;

namespace Jiratt.Common {
    /// <summary>
    /// </summary>
    public class RelayCommand : ICommand {
        private readonly Func<bool> _canExecute;

        private readonly Action _execute;

        /// <summary>
        ///     Erzeugt einen RelayCommand mit einem Namen, einem Methoden Delegaten und einem Predicate Delegaten welche beide
        ///     einen Parameter übergeben.
        ///     Der Methoden Delegate stellt die Execute Methode des ICommand Interfaces dar.
        ///     Der Predicate Delegate stellt die CanExecute Methode dar.
        /// </summary>
        /// <param name="execute">Der Methoden Delegate für die Execute Methode</param>
        /// <param name="canExecute">Der Predicate Delegate für die CanExecute Methode</param>
        public RelayCommand(Action execute, Func<bool> canExecute = null) {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        /// <summary>Definiert die Methode, die bestimmt, ob der Befehl im aktuellen Zustand ausgeführt werden kann.</summary>
        /// <returns>true, wenn der Befehl ausgeführt werden kann, andernfalls false.</returns>
        /// <param name="parameter">
        ///     Vom Befehl verwendete Daten.Wenn der Befehl keine Datenübergabe erfordert, kann das Objekt auf
        ///     null festgelegt werden.
        /// </param>
        [DebuggerStepThrough]
        public bool CanExecute(object parameter) {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        ///     Wird gefeuert wenn sich der CanExecute Status des Commands ändert.
        /// </summary>
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        ///     Für die Methode aus die an die als Methoden Delegate im Konstruktor übergeben wurde
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) {
            _execute();
        }
    }
}