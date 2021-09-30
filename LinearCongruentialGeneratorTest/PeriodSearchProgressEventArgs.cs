using System;

namespace LinearCongruentialGeneratorTest
{
    public class PeriodSearchProgressEventArgs : EventArgs
    {
        private readonly int _done, _outOf;

        public PeriodSearchProgressEventArgs(int progress, int outOf = 100)
        {
            _done = progress;
            _outOf = outOf;
        }

        public int Done { get { return _done; } }
        public int OutOf { get { return _outOf; } }
    }
}
