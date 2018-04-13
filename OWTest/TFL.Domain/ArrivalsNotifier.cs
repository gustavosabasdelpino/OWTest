using System;
using System.Collections.Generic;
using Tfl.Contract;
using Tfl.Dto;
using Tfl.Ioc;

namespace TFL.Domain
{
    public class ArrivalsNotifier: IDisposable
    {
        private readonly string _pointId;
        private readonly string _lineId;
        private readonly ITflReader _tflReader;

        public IEnumerable<Arrival> NextArrivals { get; private set; }

        public ArrivalsNotifier(string pointId, string lineId, ITflReader tflReader= null)
        {
            _pointId = pointId;
            _lineId = lineId;
            _tflReader = tflReader ?? ImplementationsProvider.GeTflReader();
        }


        public void Initialize()
        {
            NextArrivals = _tflReader.GetNextArrivals(_pointId, _lineId);
        }

        public void Dispose()
        {
        }
    }
}