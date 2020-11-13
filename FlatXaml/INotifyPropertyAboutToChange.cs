using System;

namespace FlatXaml
{
    public interface INotifyPropertyAboutToChange
    {
        event EventHandler<PropertyAboutToChangeEventArgs> PropertyAboutToChange;
    }

    public class PropertyAboutToChangeEventArgs
    {
        public string PropertyName { get; }
        
        public object? OldValue { get; }
        
        public object? NewValue { get; }

        public PropertyAboutToChangeEventArgs(string? propertyName, object? oldValue, object? newValue)
        {
            PropertyName = propertyName ?? throw new ArgumentNullException(nameof(propertyName));
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}