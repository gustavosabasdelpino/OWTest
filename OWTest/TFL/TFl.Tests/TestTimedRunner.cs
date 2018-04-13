using System;
using Tfl.Contract;

namespace TFl.Tests
{
    public class TestTimedRunner : ITimedRunner
    {
        private  Action _actioToRun;

        public void TickNow()
        {
            _actioToRun();
        }

        public void Dispose()
        {
            
        }

        public void Start()
        {
            
        }

        public void Stop()
        {
            
        }

        public void SetActionToRun(Action action)
        {
            _actioToRun = action;
        }
    }
}