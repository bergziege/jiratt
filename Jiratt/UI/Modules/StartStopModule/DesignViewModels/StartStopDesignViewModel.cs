using Prism.Commands;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.StartStopModule.DesignViewModels {
    public class StartStopDesignViewModel : BindableBase, IStartStopViewModel {
        public StartStopDesignViewModel() {
            
        }

        public DelegateCommand StartStopCommand { get; private set; }
    }
}