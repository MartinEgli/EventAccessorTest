using EventAccessorTest.Annotations;
using System;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

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
            Add(value, (s, args) => value(Sender, args));

        public void Raise([CallerMemberName] string name = "")
        {
            foreach (var eventHandler in Collection.Handlers.ToArray())
            {
                eventHandler.Invoke(Sender, new PropertyChangingEventArgs(name));
            }
        }
    }
}