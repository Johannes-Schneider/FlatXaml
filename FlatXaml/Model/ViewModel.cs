using System;
using System.Windows;
using System.Windows.Threading;

namespace FlatXaml.Model
{
    public abstract class ViewModel : NotifyPropertyChanged
    {
        protected ViewModel(Dispatcher? eventDispatcher) : base(eventDispatcher) { }
        
        protected ViewModel() : base(Application.Current?.Dispatcher ?? throw new NullReferenceException($"Unable to retrieve the {nameof(Dispatcher)} of the current {nameof(Application)}!")) { }
    }
}