using System;
using System.IO;

namespace LinearCongruentialGeneratorTest
{
    public class LinearCongruentialGeneratorFileDecorator : LinearCongruentialGeneratorAbstractDecorator, IDisposable
    {
        private StreamWriter _streamWriter;

        public LinearCongruentialGeneratorFileDecorator(
            LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator,
            string filename)
            : base(linearCongruentialGenerator)
        {
            _streamWriter = new StreamWriter(filename);
        }

        public void Dispose()
        {
            _streamWriter.Close();
        }

        public override ulong Next()
        {
            var currentValue = _linearCongruentialGenerator.Next();

            _streamWriter.WriteLine(currentValue);

            return currentValue;
        }
    }
}
