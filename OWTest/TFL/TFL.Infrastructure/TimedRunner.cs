using System;
using System.Timers;
using Tfl.Contract;

namespace TFL.Infrastructure
{
    public class TimedRunner : ITimedRunner
    {
        private readonly Timer timer;
        private  Action actionToRun;

        public TimedRunner(double interval)
        {
            timer = new Timer {Interval = interval};   
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

        public void SetActionToRun(Action action)
        {
            actionToRun = action;
        }

        public void Dispose()
        {
            Stop();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            actionToRun();
        }

    }
}