using LinearCongruentialGeneratorTest.Command;
using LinearCongruentialGeneratorTest.Commands;
using LinearCongruentialGeneratorTest.Services;
using LinearCongruentialGeneratorTest.Services.Abstractions;
using LinearCongruentialGeneratorTest.Services.Implementations;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace LinearCongruentialGeneratorTest.ViewModel
{
    class LinearCongruentialGeneratorViewModel : AbstractViewModel, INotifyDataErrorInfo
    {
        private int _seed;
        private long _modulus = int.MaxValue;
        private int _multiplier = LinearCongruentialGenerator.LinearCongruentialGenerator.RecommendedMultiplier;
        private int _increment;

        private int _n = 1;

        public int Seed
        {
            get => _seed;
            set
            {
                if (_seed.Equals(value))
                {
                    return;
                }
                _seed = value;

                _errorsViewModel.ClearErrors(nameof(Seed));
                if (_seed < 0)
                {
                    _errorsViewModel.AddError(nameof(Seed), "Invalid seed.");
                }

                RaisePropertyChanged(nameof(Seed));
            }
        }

        public long Modulus
        {
            get => _modulus;
            set
            {
                if (_modulus.Equals(value))
                {
                    return;
                }
                _modulus = value;

                _errorsViewModel.ClearErrors(nameof(Modulus));
                if (_modulus < 0)
                {
                    _errorsViewModel.AddError(nameof(Modulus), "Invalid modulus.");
                }

                RaisePropertyChanged(nameof(Modulus));
            }
        }

        public int Multiplier
        {
            get => _multiplier;
            set
            {
                if (_multiplier.Equals(value))
                {
                    return;
                }
                _multiplier = value;

                _errorsViewModel.ClearErrors(nameof(Multiplier));
                if (_multiplier < 0)
                {
                    _errorsViewModel.AddError(nameof(Multiplier), "Invalid multiplier.");
                }

                RaisePropertyChanged(nameof(Multiplier));
            }
        }

        public int Increment
        {
            get => _increment;
            set
            {
                if (_increment.Equals(value))
                {
                    return;
                }
                _increment = value;

                _errorsViewModel.ClearErrors(nameof(Increment));
                if (_increment < 0)
                {
                    _errorsViewModel.AddError(nameof(Increment), "Invalid increment.");
                }

                RaisePropertyChanged(nameof(Increment));
            }
        }

        public int N
        {
            get => _n;
            set
            {
                if (_n.Equals(value))
                {
                    return;
                }
                _n = value;

                _errorsViewModel.ClearErrors(nameof(N));
                if (_n < 0)
                {
                    _errorsViewModel.AddError(nameof(N), "Invalid N.");
                }

                RaisePropertyChanged(nameof(N));
            }
        }

        private string _status = string.Empty;

        public string Status
        {
            get => _status;
            set
            {
                if (_status.Equals(value))
                {
                    return;
                }
                _status = value;
                RaisePropertyChanged(nameof(Status));
            }
        }

        private uint? _period;

        public uint? Period
        {
            get => _period;
            set
            {
                if (_period.Equals(value))
                {
                    return;
                }
                _period = value;
                RaisePropertyChanged(nameof(Period));
            }
        }

        private int _progressDone;

        public int ProgressDone
        {
            get => _progressDone;
            set
            {
                if (_progressDone.Equals(value))
                {
                    return;
                }
                _progressDone = value;
                RaisePropertyChanged(nameof(ProgressDone));
                RaisePropertyChanged(nameof(IsPeriodSearchInProgress));
            }
        }

        private int _progressMaximum;

        public int ProgressMaximum
        {
            get => _progressMaximum;
            set
            {
                if (_progressMaximum.Equals(value))
                {
                    return;
                }
                _progressMaximum = value;
                RaisePropertyChanged(nameof(ProgressMaximum));
                RaisePropertyChanged(nameof(IsPeriodSearchInProgress));
            }
        }

        public bool IsPeriodSearchInProgress
        {
            get => ProgressDone != ProgressMaximum;
        }

        private readonly ErrorsViewModel _errorsViewModel = new ErrorsViewModel();

        private string _dumpFilePath = "DumpGenerated.txt";

        //TODO: Needs to be injected!
        private ILinearCongruentialGeneratorPeriodFinder _linearCongruentialGeneratorPeriodFinder = new LinearCongruentialGeneratorPeriodFinderOptimal();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;

        public ObservableCollection<uint> GeneratedValues { get; set; } = new ObservableCollection<uint>();

        public RelayCommand GenerateCommand { get; set; }
        public AsyncCommand CalculatePeriodCommand { get; set; }
        public RelayCommand OpenGeneratedFileCommand { get; set; }

        public bool HasErrors => _errorsViewModel.HasErrors;

        public LinearCongruentialGeneratorViewModel()
        {
            _errorsViewModel.ErrorsChanged += OnErrorsChanged;

            GenerateCommand = new RelayCommand(o => OnGenerate(), c => CanGenerate());
            CalculatePeriodCommand = new AsyncCommand(o => OnCalculatePeriod(), c => CanCalculatePeriod());
            OpenGeneratedFileCommand = new RelayCommand(o => OpenGeneratedFile(), c => CanOpenGeneratedFile());
        }

        private void OnGenerate()
        {
            var linearCongruentialGenerator =
                new LinearCongruentialGenerator.LinearCongruentialGenerator(
                    (uint)Seed,
                    (uint)Modulus,
                    (uint)Multiplier,
                    (uint)Increment);

            GeneratedValues.Clear();

            Enumerable.Range(0, (int)N)
                .ToList()
                .ForEach(x => GeneratedValues.Add(linearCongruentialGenerator.Next()));

            using (TextWriter textwriter = new StreamWriter(_dumpFilePath))
                foreach (int value in GeneratedValues)
                    textwriter.WriteLine(value);
        }

        private bool CanGenerate()
        {
            return !HasErrors;
        }

        private void UpdatePeriodSearchProgress(object sender, PeriodSearchProgressEventArgs periodSearchProgressEventArgs)
        {
            ProgressDone = periodSearchProgressEventArgs.Done;
            ProgressMaximum = periodSearchProgressEventArgs.OutOf;
        }

        private async Task OnCalculatePeriod()
        {
            var linearCongruentialGenerator =
                new LinearCongruentialGenerator.LinearCongruentialGenerator(
                    (uint)Seed,
                    (uint)Modulus,
                    (uint)Multiplier,
                    (uint)Increment);

            Status = "In progress of finding period...";

            _linearCongruentialGeneratorPeriodFinder.PeriodSearchProgressChanged += UpdatePeriodSearchProgress;
            Period = await _linearCongruentialGeneratorPeriodFinder.Find(linearCongruentialGenerator);
            Status = "The period for these parameters is following:";
            _linearCongruentialGeneratorPeriodFinder.PeriodSearchProgressChanged -= UpdatePeriodSearchProgress;
        }

        private bool CanCalculatePeriod()
        {
            return !HasErrors;
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

        public IEnumerable GetErrors(string propertyName)
        {
            return _errorsViewModel.GetErrors(propertyName);
        }

        private void OnErrorsChanged(object sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(this, e);
            RaisePropertyChanged(nameof(CanGenerate));
            RaisePropertyChanged(nameof(CanCalculatePeriod));
        }
    }
}
