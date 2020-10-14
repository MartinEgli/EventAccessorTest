namespace EventAccessorTest
{
    public class ViewModel : BindableBase
    {
        public EventViewModelWithAccessorToInner EventViewModelWithAccessorToInner { get; } = new EventViewModelWithAccessorToInner();
        public EventViewModel EventViewModel { get; } = new EventViewModel();
        public EventViewModelWithAccessorToInnerAndParentAsSender EventViewModelWithAccessorToInnerAndParentAsSender { get; } = new EventViewModelWithAccessorToInnerAndParentAsSender();
    }
}