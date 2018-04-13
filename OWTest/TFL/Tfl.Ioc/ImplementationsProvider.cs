using System;
using Tfl.Contract;
using Tfl.Repository;
using TFL.Infrastructure;

namespace Tfl.Ioc
{
    public static class ImplementationsProvider
    {
        public static ITflReader GeTflReader()
        {
            return new TflReader();
        }

        public static IDeviceNotifier GetDeviceNotifier()
        {
            return new FakeDeviceNotifier();
        }

        public static ITimedRunner GetTimedRunner(Action actionToRun)
        {
            return new TimedRunner(300);
        }
    }
}
