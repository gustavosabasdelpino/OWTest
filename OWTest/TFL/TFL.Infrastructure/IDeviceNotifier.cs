using System.Collections.Generic;

namespace TFL.Infrastructure
{
    public interface IDeviceNotifier
    {
        IList<string> ReceivedNotifications { get; }
        void SendArrival(string text);
        void SendFollowingArrivals(IEnumerable<string> texts);
    }
}
