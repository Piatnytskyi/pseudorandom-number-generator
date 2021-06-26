using System;

namespace LinearCongruentialGenerator
{
    public class LinearCongruentialGenerator
    {
        private int _x;
        private readonly int _m;
        private readonly int _a;
        private readonly int _c;

        public LinearCongruentialGenerator(int seed, int m = int.MaxValue, int a = 48271, int c = 0)
        {
            _x = seed != -1 ? seed : (int)(DateTime.Now.Ticks % m);

            _m = m;
            _a = a;

            _c = c;
        }

        public int Next()
        {
            _x = ((_a * _x) + _c) % _m;

            return _x;
        }
    }
}
