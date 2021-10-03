namespace LinearCongruentialGeneratorTest
{
    public abstract class LinearCongruentialGeneratorAbstractDecorator : LinearCongruentialGenerator.LinearCongruentialGenerator
    {
        protected LinearCongruentialGenerator.LinearCongruentialGenerator _linearCongruentialGenerator;

        public LinearCongruentialGeneratorAbstractDecorator(
            LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator)
            : base(
                  linearCongruentialGenerator.Seed,
                  linearCongruentialGenerator.Modulus,
                  linearCongruentialGenerator.Multiplier,
                  linearCongruentialGenerator.Increment)
        {
            _linearCongruentialGenerator = linearCongruentialGenerator;
        }

        public void SetComponent(LinearCongruentialGenerator.LinearCongruentialGenerator component)
        {
            _linearCongruentialGenerator = component;
        }

        public override ulong Next()
        {
            return _linearCongruentialGenerator.Next();
        }
    }
}
