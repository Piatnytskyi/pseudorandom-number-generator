using LinearCongruentialGeneratorTest.Command;
using LinearCongruentialGeneratorTest.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace LinearCongruentialGeneratorTest.ViewModel
{
    class LinearCongruentialGeneratorViewModel
    {
        private string _dumpFilePath = "DumpGenerated.txt";

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

            using (TextWriter textwriter = new StreamWriter(_dumpFilePath))
                foreach (int value in GeneratedValues)
                    textwriter.WriteLine(value);
        }

        private void OpenGeneratedFile()
        {
            using (Process explorer = new Process())
            {
                explorer.StartInfo.FileName = "explorer";
                explorer.StartInfo.Arguments = "\"" + Path.Combine(Environment.CurrentDirectory, _dumpFilePath) + "\"";
                explorer.Start();
            }
        }

        private bool CanOpenGeneratedFile()
        {
            return File.Exists(_dumpFilePath) && new FileInfo(_dumpFilePath).Length != 0;
        }
    }
}
