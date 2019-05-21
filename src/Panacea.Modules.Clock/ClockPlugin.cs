using Panacea.Core;
using Panacea.Modularity;
using Panacea.Modularity.UiManager;
using System.Threading.Tasks;

namespace Panacea.Modules.Clock
{
    public class ClockPlugin : IPlugin
    {
        private readonly PanaceaServices _core;
        ClockControlViewModel _clock;

        public ClockPlugin(PanaceaServices core)
        {
            _core = core;
            _clock = new ClockControlViewModel();
        }

        public Task BeginInit()
        {
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            
        }

        public Task EndInit()
        {
            _core.GetUiManager().AddNavigationBarControl(_clock);
            return Task.CompletedTask;
        }

        public Task Shutdown()
        {
            _core.GetUiManager().RemoveNavigationBarControl(_clock);
            return Task.CompletedTask;
        }
    }
}
