using System;
using System.Collections.Generic;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public abstract class EventHandlerMapperBase<TEventHandler>
    {
        private readonly Dictionary<TEventHandler, TEventHandler> _eventHandlerDictionary = new Dictionary<TEventHandler, TEventHandler>();

        private Action<TEventHandler> _unsubscribe;

        public void Add([NotNull] TEventHandler value, [NotNull] Action<TEventHandler> subscribe, [NotNull] Action<TEventHandler> unsubscribe,
            TEventHandler inner)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            if (subscribe == null) throw new ArgumentNullException(nameof(subscribe));
            _unsubscribe = unsubscribe ?? throw new ArgumentNullException(nameof(unsubscribe));
            _eventHandlerDictionary.Add(value, inner);
            subscribe(inner);
        }
        public bool Remove(TEventHandler value)
        {
            if (_eventHandlerDictionary.TryGetValue(value, out var ev))
            {
                return false;
            }

            _unsubscribe(value);
            return true;
        }
    }
}