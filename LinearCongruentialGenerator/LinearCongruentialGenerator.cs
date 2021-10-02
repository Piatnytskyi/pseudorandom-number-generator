using System;

namespace LinearCongruentialGenerator
{
    public class LinearCongruentialGenerator : ICloneable
    {
        public const int RecommendedMultiplier = 48271;

        private uint _seed;
        private readonly uint _modulus;
        private readonly uint _multiplier;
        private readonly uint _increment;

        public uint Seed { get; }
        public uint Modulus { get; }
        public uint Multiplier { get; }
        public uint Increment { get; }

        public LinearCongruentialGenerator(
            uint? seed,
            uint modulus = int.MaxValue,
            uint multiplier = RecommendedMultiplier,
            uint increment = 0)
        {
            _seed = seed.HasValue ? seed.Value : (uint)(DateTime.Now.Ticks % modulus);

            _modulus = modulus;
            _multiplier = multiplier;

            _increment = increment;
        }

        public virtual uint Next()
        {
            return _seed = ((_multiplier * _seed) + _increment) % _modulus;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
