using LinearCongruentialGeneratorTest.Services.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinearCongruentialGeneratorTest.Services.Implementations
{
    class LinearCongruentialGeneratorPeriodFinderNaive : ILinearCongruentialGeneratorPeriodFinder
    {
        public Task<uint> Find(LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator)
        {
            List<uint> generatedValues = new List<uint>();

            uint currentValue;
            bool periodFound = false;

            while (!periodFound)
            {
                currentValue = linearCongruentialGenerator.Next();

                if (generatedValues.Count > 0 && currentValue == generatedValues.First())
                {
                    var tempValues = new List<uint>();
                    var tempLinearCongruentialGenerator = linearCongruentialGenerator.Clone() as LinearCongruentialGenerator.LinearCongruentialGenerator;

                    tempValues.Add(currentValue);
                    Enumerable.Range(0, generatedValues.Count - 1)
                        .ToList()
                        .ForEach(x => tempValues.Add(tempLinearCongruentialGenerator.Next()));

                    periodFound = Enumerable.SequenceEqual(generatedValues, tempValues);
                }

                generatedValues.Add(currentValue);
            }

            return Task.Run(() => (uint)generatedValues.Count - 1);
        }
    }
}
