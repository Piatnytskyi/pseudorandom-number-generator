using System;

namespace LinearCongruentialGenerator
{
    public class LinearCongruentialGenerator : ICloneable
    {
        public const int RecommendedMultiplier = 48271;

        private ulong _seed;
        private readonly ulong _modulus;
        private readonly ulong _multiplier;
        private readonly ulong _increment;

        public ulong Seed { get => _seed; }
        public ulong Modulus { get => _modulus; }
        public ulong Multiplier { get => _multiplier; }
        public ulong Increment { get => _increment; }

        public LinearCongruentialGenerator(
            ulong? seed,
            ulong modulus = int.MaxValue,
            ulong multiplier = RecommendedMultiplier,
            ulong increment = 0)
        {
            _seed = seed ?? (ulong)DateTime.Now.Ticks % modulus;

            _modulus = modulus;
            _multiplier = multiplier;

            _increment = increment;
        }

        public virtual ulong Next()
        {
            return _seed = ((_multiplier * _seed) + _increment) % _modulus;
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
