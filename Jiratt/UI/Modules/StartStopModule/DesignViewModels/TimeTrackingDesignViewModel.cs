using Prism.Commands;
using Prism.Mvvm;

namespace Jiratt.UI.Modules.StartStopModule.DesignViewModels {
    public class TimeTrackingDesignViewModel : BindableBase, ITimeTrackingViewModel {
        public TimeTrackingDesignViewModel() {
            
        }

        public DelegateCommand StartStopCommand { get; private set; }
    }
}