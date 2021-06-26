using System;

namespace LinearCongruentialGenerator
{
    public class LinearCongruentialGenerator
    {
        public const int RecommendedMultiplier = 48271;

        private int _seed;
        private readonly int _modulus;
        private readonly int _multiplier;
        private readonly int _increment;

        public LinearCongruentialGenerator(
            int seed,
            int modulus = int.MaxValue,
            int multiplier = RecommendedMultiplier,
            int increment = 0)
        {
            _seed = seed != -1 ? seed : (int)(DateTime.Now.Ticks % modulus);

            _modulus = modulus;
            _multiplier = multiplier;

            _increment = increment;
        }

        public int Next()
        {
            _seed = ((_multiplier * _seed) + _increment) % _modulus;

            return _seed;
        }
    }
}
