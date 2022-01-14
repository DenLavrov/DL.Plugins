using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Core
{
    public class DynamicValuesDictionary<TKey, TValue>: Dictionary<TKey, TValue>, INotifyPropertyChanged
    {
        readonly Dictionary<TKey, Func<TValue>> _valueProviders = new Dictionary<TKey, Func<TValue>>();

        public ICommand NotifyPropertiesChangedCommand { get; }

        public DynamicValuesDictionary()
        {
            NotifyPropertiesChangedCommand = new Command(NotifyPropertiesChanged);
        }

        void NotifyPropertiesChanged(object param)
        {
            switch (param)
            {
                case IEnumerable<TKey> properties:
                    foreach (var property in properties)
                        this[property] = _valueProviders[property]();
                    break;
                case TKey prop:
                    this[prop] = _valueProviders[prop]();
                    break;
                default:
                    foreach (var key in _valueProviders.Keys)
                        this[key] = _valueProviders[key]();
                    break;
            }
        }

        public void TryUpdate(TKey key, Func<TValue> valueProvider, TValue defaultValue = default)
        {
            if (_valueProviders.ContainsKey(key))
                _valueProviders[key] = valueProvider;
            else
                _valueProviders.TryAdd(key, valueProvider);
            if (ContainsKey(key))
                this[key] = defaultValue;
            else
                TryAdd(key, defaultValue);
            OnPropertyChanged($"Item[{key}]");
        }

        public new TValue this[TKey key]
        {
            get => ((Dictionary<TKey, TValue>) this)[key];
            set
            {
                ((Dictionary<TKey, TValue>) this)[key] = value;
                OnPropertyChanged($"Item[{key}]");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
