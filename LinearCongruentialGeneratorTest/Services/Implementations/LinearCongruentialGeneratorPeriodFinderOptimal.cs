using LinearCongruentialGeneratorTest.Services.Abstractions;
using System.Threading.Tasks;

namespace LinearCongruentialGeneratorTest.Services.Implementations
{
    class LinearCongruentialGeneratorPeriodFinderOptimal : ILinearCongruentialGeneratorPeriodFinder
    {
        public Task<uint> Find(LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator)
        {
            return Task.Run(() => {
                var currentValue = linearCongruentialGenerator.Next();
                var period = 0u;
                var firstValue = currentValue;

                for (var periodFound = false; !periodFound; ++period)
                {
                    var previousValue = currentValue;
                    currentValue = linearCongruentialGenerator.Next();

                    if (currentValue == firstValue || currentValue == previousValue)
                        periodFound = true;
                }

                return period;
            });
        }
    }
}
