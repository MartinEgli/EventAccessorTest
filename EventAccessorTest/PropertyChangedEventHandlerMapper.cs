using EventAccessorTest.Annotations;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace EventAccessorTest
{
    public class PropertyChangedEventHandlerMapper : EventHandlerMapperBase<PropertyChangedEventHandler>
    {
        public PropertyChangedEventHandlerMapper([NotNull] Action<PropertyChangedEventHandler> subscribe,
            [NotNull] Action<PropertyChangedEventHandler> unsubscribe,
            [CanBeNull] object sender = null) : base(subscribe, unsubscribe, sender)
        {
        }

        public void Add([NotNull] PropertyChangedEventHandler value) =>
            Add(value, (s, args) => value(Sender, args));

        public void Raise([CallerMemberName] string name = null)
        {
            foreach (var eventHandler in Collection.Handlers.ToArray())
            {
                eventHandler.Invoke(Sender, new PropertyChangedEventArgs(name));
            }
        }
    }
}