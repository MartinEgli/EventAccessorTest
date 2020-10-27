namespace EventAccessorTest
{
    public partial class EventHandleCollection<TEventHandler>
    {
        private class EventHandleStruct
        {
            public EventHandleStruct(TEventHandler eventHandler)
            {
                EventHandler = eventHandler;
                Count = 0;
            }

            public TEventHandler EventHandler { get; }

            public void Increment()
            {
                Count++;
            }

            public void Decrement()
            {
                Count--;
            }
            public int Count { get; private set; }
            }
        }
}