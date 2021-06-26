using LinearCongruentialGeneratorTest.Command;
using LinearCongruentialGeneratorTest.Model;
using LinearCongruentialGenerator;
using System.Collections.ObjectModel;
using System.Linq;

namespace LinearCongruentialGeneratorTest.ViewModel
{
    class LinearCongruentialGeneratorViewModel
    {
        public LinearCongruentialGeneratorModel LinearCongruentialGenerator;

        public ObservableCollection<int> GeneratedValues { get; set; }

        public RelayCommand GenerateCommand { get; set; }

        public LinearCongruentialGeneratorViewModel()
        {
            GenerateCommand = new RelayCommand(o => OnGenerate());
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

            Enumerable.Range(0, LinearCongruentialGenerator.N)
                .ToList()
                .ForEach(x => GeneratedValues.Add(linearCongruentialGenerator.Next()));
        }
    }
}
