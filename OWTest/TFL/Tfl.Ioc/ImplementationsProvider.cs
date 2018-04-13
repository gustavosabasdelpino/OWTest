using Tfl.Contract;
using Tfl.Repository;

namespace Tfl.Ioc
{
    public static class ImplementationsProvider
    {
        public static ITflReader GeTflReader()
        {
            return new TflReader();
        }
    }
}
