using System;
using System.ComponentModel;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public class PropertyChangingEventHandlerMapper : EventHandlerMapperBase<PropertyChangingEventHandler>
    {
        private readonly object _sender;

        public PropertyChangingEventHandlerMapper(object sender) => _sender = sender;

        public void Add([NotNull] PropertyChangingEventHandler value, [NotNull] Action<PropertyChangingEventHandler> subscribe,
            [NotNull] Action<PropertyChangingEventHandler> unsubscribe) =>
            Add(value, subscribe, unsubscribe, (s, e) => value(_sender, e));
    }
}