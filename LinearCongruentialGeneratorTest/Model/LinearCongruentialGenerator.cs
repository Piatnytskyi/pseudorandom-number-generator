using System.ComponentModel;

namespace LinearCongruentialGeneratorTest.Model
{
    public class LinearCongruentialGenerator : AbstractModel
    {
        private int seed;
        private int m;
        private int a;
        private int c;

        public int Seed
        {
            get => seed;
            set
            {
                if (seed.Equals(value))
                {
                    return;
                }
                seed = value;
                RaisePropertyChanged(nameof(seed));
            }
        }

        public int M
        {
            get => m;
            set
            {
                if (m.Equals(value))
                {
                    return;
                }
                m = value;
                RaisePropertyChanged(nameof(m));
            }
        }

        public int A
        {
            get => a;
            set
            {
                if (a.Equals(value))
                {
                    return;
                }
                a = value;
                RaisePropertyChanged(nameof(a));
            }
        }

        public int C
        {
            get => c;
            set
            {
                if (c.Equals(value))
                {
                    return;
                }
                c = value;
                RaisePropertyChanged(nameof(c));
            }
        }
    }
}
