using System;

namespace Tfl.Dto
{
    public class Arrival
    {
        public string Destination { get; }
        public DateTime ExpectedDateTime { get; }


        public Arrival(string destinationName, DateTime expectedArrival)
        {
            Destination = destinationName;
            ExpectedDateTime = expectedArrival;
        }
    }
}