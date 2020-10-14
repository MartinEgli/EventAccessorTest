namespace EventAccessorTest
{
    public class ViewModel : BindableBase
    {
        public ViewModel1 ViewModel1 { get; } = new ViewModel1();
        public ViewModel2 ViewModel2 { get; } = new ViewModel2();
        public ViewModel3 ViewModel3 { get; } = new ViewModel3();
    }
}