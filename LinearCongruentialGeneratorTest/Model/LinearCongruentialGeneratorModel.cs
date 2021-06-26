namespace LinearCongruentialGeneratorTest.Model
{
    public class LinearCongruentialGeneratorModel : AbstractModel
    {
        private int _seed;
        private int _modulus;
        private int _multiplier;
        private int _increment;

        private int _n;

        public int Seed
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

        public int Modulus
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

        public int Multiplier
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

        public int Increment
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

        public int N
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
