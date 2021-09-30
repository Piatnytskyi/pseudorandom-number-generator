using LinearCongruentialGeneratorTest.Services.Abstractions;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LinearCongruentialGeneratorTest.Services.Implementations
{
    class LinearCongruentialGeneratorPeriodFinderOptimal : ILinearCongruentialGeneratorPeriodFinder
    {
        public event EventHandler<PeriodSearchProgressEventArgs> PeriodSearchProgressChanged;

        private void OnPeriodSearchProgressChanged(PeriodSearchProgressEventArgs e)
        {
            EventHandler<PeriodSearchProgressEventArgs> temp = Volatile.Read(ref PeriodSearchProgressChanged);
            if (temp != null) temp(this, e);
        }

        public Task<uint> Find(LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator)
        {
            throw new NotImplementedException();
        }
    }
}
