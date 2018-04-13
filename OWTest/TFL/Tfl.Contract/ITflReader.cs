using System.Collections.Generic;
using Tfl.Dto;

namespace Tfl.Contract
{
    public interface ITflReader
    {
        IEnumerable<Arrival> GetNextArrivals(string stopPointId, string lineId);
    }
}