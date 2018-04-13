using System;
using System.Collections.Generic;
using Tfl.Contract;
using Tfl.Dto;
using Tfl.Ioc;
using TFL.Infrastructure;
using ITimedRunner = Tfl.Contract.ITimedRunner;

namespace TFL.Domain
{
    public class ArrivalsNotifier: IDisposable
    {
        private readonly string _pointId;
        private readonly string _lineId;
        private readonly ITimedRunner _timedRunner;
        private readonly IDeviceNotifier _notifier;
        private readonly ITflReader _tflReader;

        public IEnumerable<Arrival> NextArrivals { get; private set; }

        public ArrivalsNotifier(string pointId, string lineId, 
            ITflReader tflReader= null, 
            IDeviceNotifier notifier= null,
            ITimedRunner timedRunner = null)
        {
            _pointId = pointId;
            _lineId = lineId;
            _timedRunner = timedRunner??ImplementationsProvider.GetTimedRunner(GetArrivals);
            _notifier = notifier?? ImplementationsProvider.GetDeviceNotifier();
            _tflReader = tflReader ?? ImplementationsProvider.GeTflReader();
        }


        public void Initialize()
        {
            GetArrivals();
        }

        private void GetArrivals()
        {
            NextArrivals = _tflReader.GetNextArrivals(_pointId, _lineId);
        }

        public void Dispose()
        {
        }
    }
}