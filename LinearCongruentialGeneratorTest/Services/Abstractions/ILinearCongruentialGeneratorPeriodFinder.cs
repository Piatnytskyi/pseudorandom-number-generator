using System.Threading.Tasks;

namespace LinearCongruentialGeneratorTest.Services.Abstractions
{
    interface ILinearCongruentialGeneratorPeriodFinder
    {
        public Task<uint> Find(LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator);
    }
}
