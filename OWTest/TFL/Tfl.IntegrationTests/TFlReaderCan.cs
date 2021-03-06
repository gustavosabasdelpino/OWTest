﻿using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tfl.Repository;

namespace Tfl.IntegrationTests
{
    [TestClass]
    public class TFlReaderCan
    {
        [TestMethod]
        public void ObtainArrivals()
        {
            TflReader reader = new TflReader();
            var arrivals = reader.GetNextArrivals("940GZZLUWLO", "bakerloo");
            Assert.IsTrue(arrivals.Any());
        }
    }
}
