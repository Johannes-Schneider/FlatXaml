using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

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
            
            OnEventDispatcher(() => PropertyAboutToChange.Invoke(this, new PropertyAboutToChangeEventArgs(propertyName, oldValue, newValue)));
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            
            OnEventDispatcher(() => PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName)));
        }

        protected void OnEventDispatcher(Action action)
        {
            if (EventDispatcher == null || EventDispatcher.CheckAccess())
            {
                action.Invoke();
            }
            else
            {
                EventDispatcher.Invoke(action);
            }
        }
    }

    public static class NotifyPropertyChangedExtensions
    {
        public static bool MutateVerboseIfNotNull<TProperty>(this INotifyPropertyChanged self,
                                                             ref TProperty property,
                                                             TProperty value,
                                                             PropertyChangedEventHandler? eventHandler,
                                                             Dispatcher? dispatcher = null,
                                                             [CallerMemberName] string? propertyName = null)
        {
            if (value == null)
            {
                return false;
            }

            return self.MutateVerbose(ref property, value, eventHandler, dispatcher, propertyName);
        }
        
        public static bool MutateVerbose<TProperty>(this INotifyPropertyChanged self,
                                                    ref TProperty property,
                                                    TProperty value,
                                                    PropertyChangedEventHandler? eventHandler,
                                                    Dispatcher? dispatcher = null,
                                                    [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<TProperty>.Default.Equals(property, value))
            {
                return false;
            }

            property = value;
            if (eventHandler == null)
            {
                return true;
            }

            if (dispatcher == null || dispatcher.CheckAccess())
            {
                eventHandler.Invoke(self, new PropertyChangedEventArgs(propertyName));
            }
            else
            {
                dispatcher.Invoke(() => eventHandler.Invoke(self, new PropertyChangedEventArgs(propertyName)));
            }

            return true;
        }
    }
}