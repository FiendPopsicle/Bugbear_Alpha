using Bugbear.Stats;

namespace Bugbear.Common
{
    public class SetHealthBarCommand : ICommand
    {
        public Health health { get; set; }
        public int healthId { get; set; }
    }
}
