using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tfl.Contract;
using TFL.Domain;
using TFL.Infrastructure;

namespace TFl.Tests
{
    [TestClass]
    public class WhenAtrainArrives
    {

        [TestMethod]
        [Ignore]
        public void ArrivalIsNotified()
        {
            TestTimedRunner timedRuner = new  TestTimedRunner();
            IDeviceNotifier deviceNotifier = new FakeDeviceNotifier();
            ArrivalsNotifier arrivalsNotifier = new ArrivalsNotifier(string.Empty, string.Empty, 
                new FakeTflReader(),
                deviceNotifier,
                timedRuner);
            arrivalsNotifier.Initialize();
            timedRuner.TickNow();
            Assert.AreEqual(1, deviceNotifier.ReceivedNotifications.Count);

        }
    }
}
