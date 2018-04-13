using System;
using System.Collections.Generic;
using Tfl.Contract;
using Tfl.Dto;

namespace TFl.Tests
{
    class FakeTflReader : ITflReader
    {
        public IEnumerable<Arrival> GetNextArrivals(string stopPointId, string lineId)
        {
            return new List<Arrival>()
            {
                new Arrival("Wimbledon", new DateTime(2018,01,01,12,0,0)),
                new Arrival("Sutton", new DateTime(2018,01,01,12,10,0)),
            };
        }
    }
}