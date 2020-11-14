using System;
using FlatXaml.Annotations;

namespace FlatXaml.Model
{
    public class Progression : ViewModel
    {
        public event EventHandler? Completed;
        
        private const double UpdateProgressThreshold = 0.001d;
        private const int MinimumNumberOfSteps = 1;
        private const double MinimumProgress = 0.0d;
        private const double MaximumProgress = 1.0d;

        private string _headline = string.Empty;

        [NotNull]
        public string Headline
        {
            get => _headline;
            set => MutateVerboseIfNotNull(ref _headline, value);
        }

        private string _currentStepDescription = string.Empty;

        [NotNull]
        public string CurrentStepDescription
        {
            get => _currentStepDescription;
            set => MutateVerboseIfNotNull(ref _currentStepDescription, value);
        }
        
        private int _totalNumberOfSteps = MinimumNumberOfSteps;

        public int TotalNumberOfSteps
        {
            get => _totalNumberOfSteps;
            set
            {
                if (value < MinimumNumberOfSteps)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (!MutateVerbose(ref _totalNumberOfSteps, value))
                {
                    return;
                }
                
                UpdateTotalProgress();
            }
        }

        private int _currentStepNumber = 0;

        public int CurrentStepNumber
        {
            get => _currentStepNumber;
            set
            {
                if (value < CurrentStepNumber)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (!MutateVerbose(ref _currentStepNumber, value))
                {
                    return;
                }
                
                UpdateTotalProgress();
            }
        }

        private double _currentStepProgress = MinimumProgress;

        public double CurrentStepProgress
        {
            get => _currentStepProgress;
            set
            {
                if (value < MinimumProgress || value > MaximumProgress)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }

                if (!value.Equals(MaximumProgress) && Math.Abs(value - CurrentStepProgress) < UpdateProgressThreshold)
                {
                    return;
                }

                MutateVerbose(ref _currentStepProgress, value);
            }
        }

        private double _totalProgress = MinimumProgress;

        public double TotalProgress
        {
            get => _totalProgress;
            private set
            {
                if (value < MinimumProgress || value > MaximumProgress)
                {
                    throw new ArgumentOutOfRangeException(nameof(value));
                }
                
                if (!value.Equals(MaximumProgress) && Math.Abs(value - TotalProgress) < UpdateProgressThreshold)
                {
                    return;
                }

                if (!MutateVerbose(ref _totalProgress, value))
                {
                    return;
                }

                if (value.Equals(MaximumProgress))
                {
                    IsCompleted = true;
                }
            }
        }

        private bool _isCompleted = false;

        public bool IsCompleted
        {
            get => _isCompleted;
            private set
            {
                if (IsCompleted)
                {
                    return;
                }
                
                if (!MutateVerbose(ref _isCompleted, value))
                {
                    return;
                }

                if (Completed == null)
                {
                    return;
                }

                if (EventDispatcher == null || EventDispatcher.CheckAccess())
                {
                    Completed.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    EventDispatcher.Invoke(() => Completed.Invoke(this, EventArgs.Empty));
                }
            }
        }

        private void UpdateTotalProgress()
        {
            var totalProgressPerStep = 1.0d / TotalNumberOfSteps;
            TotalProgress = Math.Max(0, CurrentStepNumber - 1) * totalProgressPerStep + CurrentStepProgress * totalProgressPerStep;
        }
        
        public void StartNextStep(string? stepDescription)
        {
            CurrentStepDescription = stepDescription ?? throw new ArgumentNullException(nameof(stepDescription));
            CurrentStepNumber = Math.Min(TotalNumberOfSteps, CurrentStepNumber + 1);
            CurrentStepProgress = MinimumProgress;
        }
        
        public void Done()
        {
            CurrentStepDescription = string.Empty;
            CurrentStepNumber = TotalNumberOfSteps;
            CurrentStepProgress = 1.0d;
        }
    }
}