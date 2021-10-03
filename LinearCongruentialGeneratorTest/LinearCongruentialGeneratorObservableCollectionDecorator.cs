using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace LinearCongruentialGeneratorTest
{
    public class LinearCongruentialGeneratorObservableCollectionDecorator : LinearCongruentialGeneratorAbstractDecorator
    {
        private ObservableCollection<ulong> _observableCollection;

        public LinearCongruentialGeneratorObservableCollectionDecorator(
            LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator,
            ObservableCollection<ulong> observableCollection)
            : base(linearCongruentialGenerator)
        {
            _observableCollection = observableCollection;
        }

        public override ulong Next()
        {
            var currentValue = _linearCongruentialGenerator.Next();
            Application.Current.Dispatcher.BeginInvoke(new Action(() => _observableCollection.Add(currentValue)));

            return currentValue;
        }
    }
}
