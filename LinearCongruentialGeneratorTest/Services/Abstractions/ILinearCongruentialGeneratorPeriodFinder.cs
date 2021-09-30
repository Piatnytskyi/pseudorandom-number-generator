using System;
using System.Threading.Tasks;

namespace LinearCongruentialGeneratorTest.Services.Abstractions
{
    interface ILinearCongruentialGeneratorPeriodFinder
    {
        public event EventHandler<PeriodSearchProgressEventArgs> PeriodSearchProgressChanged;

        public Task<uint> Find(LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator);
    }
}
