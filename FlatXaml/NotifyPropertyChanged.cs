using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;
using FlatXaml.Annotations;

namespace FlatXaml
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged, INotifyPropertyAboutToChange
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        public event EventHandler<PropertyAboutToChangeEventArgs>? PropertyAboutToChange;

        protected Dispatcher? EventDispatcher { get; }

        protected NotifyPropertyChanged(Dispatcher? eventDispatcher = null)
        {
            EventDispatcher = eventDispatcher;
        }

        protected bool MutateVerboseIfNotNull<TPropertyType>(ref TPropertyType property, TPropertyType value, [CallerMemberName] string? propertyName = null)
        {
            if (value == null)
            {
                return false;
            }

            return MutateVerbose(ref property, value, propertyName);
        }

        protected bool MutateVerbose<TPropertyType>(ref TPropertyType property, TPropertyType value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<TPropertyType>.Default.Equals(property, value))
            {
                return false;
            }

            OnPropertyAboutToChange(property, value, propertyName);
            property = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        protected virtual void OnPropertyAboutToChange(object? oldValue, object? newValue, [CallerMemberName] string? propertyName = null)
        {
            if (PropertyAboutToChange == null)
            {
                return;
            }

            if (EventDispatcher == null || EventDispatcher.CheckAccess())
            {
                PropertyAboutToChange.Invoke(this, new PropertyAboutToChangeEventArgs(propertyName, oldValue, newValue));
            }
            else
            {
                EventDispatcher.Invoke(() => PropertyAboutToChange.Invoke(this, new PropertyAboutToChangeEventArgs(propertyName, oldValue, newValue)));
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (PropertyChanged == null)
            {
                return;
            }

            if (EventDispatcher == null || EventDispatcher.CheckAccess())
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                EventDispatcher.Invoke(() => PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName)));
            }
        }
    }
}