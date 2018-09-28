using Jiratt.Common;
using Prism.Commands;

namespace Jiratt.UI.Modules.NavBack.DesignViewModels {
    /// <summary>
    ///     Design View Model eines "zurück" Buttons
    /// </summary>
    public class NavBackDesignViewModel : INavBackViewModel {
        /// <summary>
        ///     Liefert ein Command um die Navigation auszulösen
        /// </summary>
        public RelayCommand NavigateBackCommand { get; }
    }
}