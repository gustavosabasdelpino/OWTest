using System;

namespace Tfl.Contract
{
    public interface ITimedRunner
    {
        void Dispose();
        void Start();
        void Stop();
        void SetActionToRun(Action action);
    }
}