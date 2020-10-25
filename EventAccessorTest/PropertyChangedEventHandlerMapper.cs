using System;
using System.ComponentModel;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public class PropertyChangedEventHandlerMapper : EventHandlerMapperBase<PropertyChangedEventHandler>
    {
        private readonly object _sender;

        public PropertyChangedEventHandlerMapper(object sender)
        {
            _sender = sender;
        }

        public void Add([NotNull] PropertyChangedEventHandler value, [NotNull] Action<PropertyChangedEventHandler> subscribe,
            [NotNull] Action<PropertyChangedEventHandler> unsubscribe) =>
            Add(value, subscribe, unsubscribe, (s, e) => value(_sender, e));
    }
}