using Prism.Commands;

namespace Jiratt.UI.Modules.StartStopModule {
    public interface ITimeTrackingViewModel {

        DelegateCommand StartStopCommand { get; }

    }
}