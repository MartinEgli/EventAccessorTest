using EventAccessorTest.Annotations;
using System;
using System.Linq;

namespace EventAccessorTest
{
    public class EventHandlerMapper<TEventArgs> : EventHandlerMapperBase<EventHandler<TEventArgs>>
        where TEventArgs : EventArgs
    {
        public EventHandlerMapper([NotNull]
        Action<EventHandler<TEventArgs>> subscribe,
        [NotNull] Action<EventHandler<TEventArgs>> unsubscribe,
        [CanBeNull] object sender = null) : base(subscribe, unsubscribe, sender)
        {
        }

        public void Add([NotNull] EventHandler<TEventArgs> value) =>
            Add(value, (s, args) => value(Sender, args));

        public void Raise(TEventArgs args)
        {
            foreach (var eventHandler in Collection.Handlers.ToArray())
            {
                eventHandler.Invoke(Sender, args);
            }
        }
    }
}