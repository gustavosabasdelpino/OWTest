using System.Collections.Generic;

namespace TFL.Infrastructure
{
    public  class FakeDeviceNotifier : IDeviceNotifier
    {
        public IList<string> ReceivedNotifications { get; private set; }

        public FakeDeviceNotifier()
        {
            ReceivedNotifications= new List<string>();
        }

        public void SendArrival(string text)
        {
            ReceivedNotifications.Add(text);
        }

        public void SendFollowingArrivals(IEnumerable<string> texts)
        {
            foreach (var text in texts)
                ReceivedNotifications.Add(text);
        }
    }
}