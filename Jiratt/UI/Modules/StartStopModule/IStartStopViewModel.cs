using Prism.Commands;

namespace Jiratt.UI.Modules.StartStopModule {
    public interface IStartStopViewModel {

        DelegateCommand StartStopCommand { get; }

    }
}