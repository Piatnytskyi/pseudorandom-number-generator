using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace LinearCongruentialGeneratorTest
{
    public class LinearCongruentialGeneratorObservableCollectionDecorator : LinearCongruentialGeneratorAbstractDecorator
    {
        private ObservableCollection<uint> _observableCollection;

        public LinearCongruentialGeneratorObservableCollectionDecorator(
            LinearCongruentialGenerator.LinearCongruentialGenerator linearCongruentialGenerator,
            ObservableCollection<uint> observableCollection)
            : base(linearCongruentialGenerator)
        {
            _observableCollection = observableCollection;
        }

        public override uint Next()
        {
            var currentValue = _linearCongruentialGenerator.Next();
            Application.Current.Dispatcher.BeginInvoke(new Action(() => _observableCollection.Add(currentValue)));

            return currentValue;
        }
    }
}
