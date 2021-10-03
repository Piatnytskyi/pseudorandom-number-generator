using System;

namespace LinearCongruentialGeneratorTest
{
    public interface IErrorHandler
    {
        void HandleError(Exception ex);
    }
}
