namespace LinearCongruentialGeneratorTest.Model
{
    public class LinearCongruentialGeneratorModel : AbstractModel
    {
        private uint _seed;
        private uint _modulus = int.MaxValue;
        private uint _multiplier = LinearCongruentialGenerator.LinearCongruentialGenerator.RecommendedMultiplier;
        private uint _increment;

        private uint _n = 1;

        public uint Seed
        {
            get => _seed;
            set
            {
                if (_seed.Equals(value))
                {
                    return;
                }
                _seed = value;
                RaisePropertyChanged(nameof(_seed));
            }
        }

        public uint Modulus
        {
            get => _modulus;
            set
            {
                if (_modulus.Equals(value))
                {
                    return;
                }
                _modulus = value;
                RaisePropertyChanged(nameof(_modulus));
            }
        }

        public uint Multiplier
        {
            get => _multiplier;
            set
            {
                if (_multiplier.Equals(value))
                {
                    return;
                }
                _multiplier = value;
                RaisePropertyChanged(nameof(_multiplier));
            }
        }

        public uint Increment
        {
            get => _increment;
            set
            {
                if (_increment.Equals(value))
                {
                    return;
                }
                _increment = value;
                RaisePropertyChanged(nameof(_increment));
            }
        }

        public uint N
        {
            get => _n;
            set
            {
                if (_n.Equals(value))
                {
                    return;
                }
                _n = value;
                RaisePropertyChanged(nameof(_n));
            }
        }
    }
}
