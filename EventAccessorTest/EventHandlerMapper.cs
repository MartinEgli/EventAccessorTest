using System;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public class EventHandlerMapper<TEventArgs> : EventHandlerMapperBase<EventHandler<TEventArgs>>
        where TEventArgs : EventArgs
    {

        public EventHandlerMapper([NotNull]
        Action<EventHandler<TEventArgs>> subscribe,
        [NotNull] Action<EventHandler<TEventArgs>> unsubscribe,
        [CanBeNull] object sender = null) : base(subscribe,unsubscribe, sender)
        {
        }

        public void Add([NotNull] EventHandler<TEventArgs> value) =>
            Add(value, (s, args) => value(Sender, args));
    }
}