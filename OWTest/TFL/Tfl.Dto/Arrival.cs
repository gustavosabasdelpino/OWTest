using System;

namespace Tfl.Dto
{
    public class Arrival
    {
        public string Destination { get; }
        public DateTime ExpecDateTime { get; }


        public Arrival(string destination, DateTime expecDateTime)
        {
            Destination = destination;
            ExpecDateTime = expecDateTime;
        }
    }
}