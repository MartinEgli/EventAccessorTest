using EventAccessorTest.Annotations;
using System;
using System.ComponentModel;

namespace EventAccessorTest
{
    public class PropertyChangingEventHandlerMapper : EventHandlerMapperBase<PropertyChangingEventHandler>
    {
        public PropertyChangingEventHandlerMapper([NotNull] Action<PropertyChangingEventHandler> subscribe,
            [NotNull] Action<PropertyChangingEventHandler> unsubscribe, [CanBeNull] object sender = null) : base(
            subscribe, unsubscribe, sender)
        {
        }

        public void Add([NotNull] PropertyChangingEventHandler value) =>
            Add(value, (s, e) => value(Sender, e));
    }
}