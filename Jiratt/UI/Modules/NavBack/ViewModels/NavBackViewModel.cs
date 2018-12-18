using System.Windows.Input;
using Jiratt.Common;
using Jiratt.UI.Shell;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace Jiratt.UI.Modules.NavBack.ViewModels {
    /// <summary>
    ///     View Model für einen "zurück" Button
    /// </summary>
    public class NavBackViewModel : BindableBase, INavBackViewModel {
        private readonly IRegionManager _regionManager;

        private RelayCommand _navigateBackCommand;

        /// <summary>
        /// </summary>
        /// <param name="regionManager"></param>
        public NavBackViewModel(IRegionManager regionManager) {
            _regionManager = regionManager;
        }

        /// <summary>
        ///     Liefert ein Command um die Navigation auszulösen
        /// </summary>
        public RelayCommand NavigateBackCommand {
            get {
                if (_navigateBackCommand == null)
                    _navigateBackCommand = new RelayCommand(NavigateBack, CanGoBack);

                return _navigateBackCommand;
            }
        }

        private bool CanGoBack() {
            return _regionManager.Regions[ShellRegionNames.CenterRegion].NavigationService.Journal.CanGoBack;
        }

        private void NavigateBack() {
            _regionManager.Regions[ShellRegionNames.CenterRegion].NavigationService.Journal.GoBack();
        }
    }
}