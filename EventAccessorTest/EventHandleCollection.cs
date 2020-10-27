using System;
using System.Collections.Generic;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public partial class EventHandleCollection<TEventHandler>
    {
        [NotNull] private readonly Dictionary<TEventHandler, EventHandleStruct> _eventHandlerDictionary = new Dictionary<TEventHandler, EventHandleStruct>();


        public bool Add(TEventHandler value, TEventHandler inner)
        {
            if (value == null) throw new ArgumentNullException(nameof(value));
            var result = false;
            if (!_eventHandlerDictionary.TryGetValue(value, out var eventTuple))
            {
                eventTuple = new EventHandleStruct(inner);
                _eventHandlerDictionary.Add(value, eventTuple);
                result = true;
            }
            eventTuple.Increment();
            return result;
        }

        public bool Remove([NotNull] TEventHandler value, out TEventHandler inner)
        {
            if (!_eventHandlerDictionary.TryGetValue(value, out var eventTuple))
            {
                inner = default;
                return false;
            }

            if (eventTuple.Count == 1)
            {
                _eventHandlerDictionary.Remove(value);
                inner = eventTuple.EventHandler;
                return true;
            }

            eventTuple.Decrement();
            inner = eventTuple.EventHandler;
            return false;

        }

        public IEnumerable<TEventHandler> Handlers => _eventHandlerDictionary.Keys;
    }
}