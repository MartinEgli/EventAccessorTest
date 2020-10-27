using EventAccessorTest.Annotations;
using System;
using System.Collections;

namespace EventAccessorTest
{
    public abstract class EventHandlerMapperBase<TEventHandler>
    {
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

        [NotNull]
        protected EventHandleCollection<TEventHandler> Collection { get; } = new EventHandleCollection<TEventHandler>();

        public void Add([NotNull] TEventHandler value,
            [NotNull] TEventHandler inner)
        {
            Collection.Add(value, inner);
            _subscribe(inner);
        }

        public void Remove([NotNull] TEventHandler value)
        {
            Collection.Remove(value, out var inner);
            if (inner != null)
            {
                _unsubscribe(inner);
            }
        }

        
    }
}