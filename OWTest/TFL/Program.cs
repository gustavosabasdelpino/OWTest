using TFL.Domain;
using Topshelf;

namespace TFL
{
    class Program
    {
        static void Main(string[] args)
        {
            var pointId = args[0];
            var lineId = args[1];
            var host = HostFactory.New(x =>
            {
                x.Service<ArrivalsNotifier>(s =>
                {
                    s.ConstructUsing(h => new ArrivalsNotifier(pointId, lineId));
                    s.WhenStarted(h => h.Initialize());
                    s.WhenStopped(h => h.Dispose());
                });

                x.RunAsLocalSystem();

                x.SetDescription("Oliver Wyman reads from TFL");
                x.SetDisplayName("Oliver Wyman reads from TFL");
                x.SetServiceName("Oliver Wyman reads from TFL");
            });

            host.Run();
        }

    }
}
