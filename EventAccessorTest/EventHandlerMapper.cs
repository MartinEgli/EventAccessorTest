using System;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public class EventHandlerMapper<TEventArgs> : EventHandlerMapperBase<EventHandler<TEventArgs>>
        where TEventArgs : EventArgs
    {
        private readonly object _sender;

        public EventHandlerMapper(object sender)
        {
            _sender = sender;
        }

        public void Add([NotNull] EventHandler<TEventArgs> value, [NotNull] Action<EventHandler<TEventArgs>> subscribe,
            [NotNull] Action<EventHandler<TEventArgs>> unsubscribe) =>
            Add(value, subscribe, unsubscribe, (s, e) => value(this, e));
    }
}