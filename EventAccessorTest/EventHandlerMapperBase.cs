using EventAccessorTest.Annotations;
using System;
using System.Collections.Generic;

namespace EventAccessorTest
{
    public abstract class EventHandlerMapperBase<TEventHandler>
    {
        [NotNull] private readonly Dictionary<TEventHandler, TEventHandler> _eventHandlerDictionary = new Dictionary<TEventHandler, TEventHandler>();
        [NotNull] private readonly Action<TEventHandler> _subscribe;
        [NotNull] private readonly Action<TEventHandler> _unsubscribe;

        protected EventHandlerMapperBase(
            [NotNull] Action<TEventHandler> subscribe,
            [NotNull] Action<TEventHandler> unsubscribe,
            [CanBeNull] object sender = null)
        {
            Sender = sender;
            _subscribe = subscribe ?? throw new ArgumentNullException(nameof(subscribe));
            _unsubscribe = unsubscribe ?? throw new ArgumentNullException(nameof(unsubscribe));
        }

        [CanBeNull] public object Sender { get; }

        public void Add([NotNull] TEventHandler value,
            [NotNull] TEventHandler inner)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));

            _eventHandlerDictionary.Add(value, inner);
            _subscribe(inner);
        }

        public bool Remove([NotNull] TEventHandler value)
        {
            if (_eventHandlerDictionary.TryGetValue(value, out var inner))
            {
                return false;
            }

            _unsubscribe(inner);
            return true;
        }
    }
}