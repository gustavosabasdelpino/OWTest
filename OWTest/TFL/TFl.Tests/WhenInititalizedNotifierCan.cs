using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFL.Domain;

namespace TFl.Tests
{
    [TestClass]
    public class WhenInititalizedNotifierCan
    {
        [TestMethod]
        public void ObtainTheArrivalPrediction()
        {
            ArrivalsNotifier arrivalsNotifier = new ArrivalsNotifier(string.Empty, string.Empty, new FakeTflReader());
            arrivalsNotifier.Initialize();
            Assert.AreEqual(2,arrivalsNotifier.NextArrivals.Count());
        }
    }
}
