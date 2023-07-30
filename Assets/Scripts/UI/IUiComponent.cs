using Bugbear.Common;

namespace Bugbear.UI
{
    public interface IUiComponent
    {
        public void SendCommand(ICommand command, string receiver);
        public void ReceiveCommand(ICommand command);
    }
}