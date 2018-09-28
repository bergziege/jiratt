using Jiratt.Common;
using Prism.Commands;

namespace Jiratt.UI.Modules.NavBack {
    /// <summary>
    ///     Schnittstelle für View Models für einen "zurück" Button
    /// </summary>
    public interface INavBackViewModel {
        /// <summary>
        ///     Liefert ein Command um die Navigation auszulösen
        /// </summary>
        RelayCommand NavigateBackCommand { get; }
    }
}