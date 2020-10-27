using EventAccessorTest.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace EventAccessorTest
{
    public abstract class EventHandlerMapperBase<TEventHandler>
    {
        private class EventHandleStruct
        {
            public EventHandleStruct(TEventHandler eventHandler)
            {
                EventHandler = eventHandler;
                Count = 0;
            }

            public TEventHandler EventHandler { get; }

            public void Increment()
            {
                Count++;
            }

            public void Decrement()
            {
                Count--;
            }
            public int Count { get; private set; }
        }

        [NotNull] private readonly Dictionary<TEventHandler, EventHandleStruct> _eventHandlerDictionary = new Dictionary<TEventHandler, EventHandleStruct>();
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

            if (!_eventHandlerDictionary.TryGetValue(value, out var eventTuple))
            {
                eventTuple = new EventHandleStruct(inner);
                _eventHandlerDictionary.Add(value, eventTuple);
            }
            eventTuple.Increment();
            _subscribe(inner);
        }

        public bool Remove([NotNull] TEventHandler value)
        {
            if (!_eventHandlerDictionary.TryGetValue(value, out var eventTuple))
            {
                return false;
            }

            if (eventTuple.Count == 1)
            {
                _eventHandlerDictionary.Remove(value);
            }
            eventTuple.Decrement();
            
            _unsubscribe(eventTuple.EventHandler);
            return true;
        }
    }
}