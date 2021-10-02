using System;
using System.IO;

namespace LinearCongruentialGeneratorTest
{
    public class LinearCongruentialGeneratorFileDecorator : LinearCongruentialGeneratorAbstractDecorator
    {
        private string _filename;

        public LinearCongruentialGeneratorFileDecorator(
            LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator,
            string filename)
            : base(linearCongruentialGenerator)
        {
            _filename = filename;
        }

        public override uint Next()
        {
            var currentValue = _linearCongruentialGenerator.Next();
            File.AppendAllText(_filename, currentValue.ToString() + Environment.NewLine);

            return currentValue;
        }
    }
}
