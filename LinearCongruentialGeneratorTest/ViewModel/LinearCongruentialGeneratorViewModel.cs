using LinearCongruentialGeneratorTest.Command;
using LinearCongruentialGeneratorTest.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace LinearCongruentialGeneratorTest.ViewModel
{
    class LinearCongruentialGeneratorViewModel
    {
        public LinearCongruentialGeneratorModel LinearCongruentialGenerator { get; set; } = new LinearCongruentialGeneratorModel();

        public ObservableCollection<uint> GeneratedValues { get; set; } = new ObservableCollection<uint>();

        public RelayCommand GenerateCommand { get; set; }
        public RelayCommand OpenGeneratedFileCommand { get; set; }

        public LinearCongruentialGeneratorViewModel()
        {
            GenerateCommand = new RelayCommand(o => OnGenerate());
            OpenGeneratedFileCommand = new RelayCommand(o => OpenGeneratedFile(), c => CanOpenGeneratedFile());
        }

        private void OnGenerate()
        {
            var linearCongruentialGenerator =
                new LinearCongruentialGenerator.LinearCongruentialGenerator(
                    LinearCongruentialGenerator.Seed,
                    LinearCongruentialGenerator.Modulus,
                    LinearCongruentialGenerator.Multiplier,
                    LinearCongruentialGenerator.Increment);

            GeneratedValues.Clear();

            Enumerable.Range(0, (int)LinearCongruentialGenerator.N)
                .ToList()
                .ForEach(x => GeneratedValues.Add(linearCongruentialGenerator.Next()));
        }

        private void OpenGeneratedFile()
        {

        }

        private bool CanOpenGeneratedFile()
        {
            throw new NotImplementedException();
        }
    }
}
