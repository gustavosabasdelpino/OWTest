using System;
using System.Timers;

namespace TFL.Infrastructure
{
    public class TimedRunner
    {
        private readonly Timer timer;
        private readonly Action actionToRun;

        public TimedRunner(Action actionToRun, double interval)
        {
            this.actionToRun = actionToRun;
            timer = new Timer {Interval = interval};
            timer.Elapsed += Timer_Elapsed;
        }

        private  void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            actionToRun();
        }

        public void Start()
        {
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
            timer.Elapsed -= Timer_Elapsed;
        }

        public void Dispose()
        {
            Stop();
        }

    }
}