using Bugbear.Common;
using Bugbear.UI;

namespace Bugbear.Managers
{
    public interface IUiManager
    {
        public void LoadUiComponent(string key, IUiComponent component);
        public void ReceiveCommand(ICommand command, string receiver);
        public void SendCommand(ICommand command, string receiver);
    }
}
