using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public class EventViewModelWithEventHandlerMapperToInner : INotifyPropertyChanged
    {
        private readonly PropertyChangedEventHandlerMapper _propertyChangedChangedEventHandlerMapper;
        private int _propertyChangedCount;

        public EventViewModelWithEventHandlerMapperToInner()
        {
            Inner = new InnerViewModel1();
            Command = new RelayCommand(_ => Inner.Publish());

            _propertyChangedChangedEventHandlerMapper = new PropertyChangedEventHandlerMapper(
                handler => Inner.PropertyChanged += handler,
                handler => Inner.PropertyChanged -= handler,
                this);

            PropertyChanged += CallPropertyChanged;
        }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _propertyChangedChangedEventHandlerMapper.Add(value);
            remove => _propertyChangedChangedEventHandlerMapper.Remove(value);
        }

        public ICommand Command { get; set; }
        public InnerViewModel1 Inner { get; set; }

        public int PropertyChangedCount
        {
            get => _propertyChangedCount;
            set
            {
                if (value == _propertyChangedCount) return;
                _propertyChangedCount = value;
                OnPropertyChanged();
            }
        }

        public string Text => Inner.Text;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            _propertyChangedChangedEventHandlerMapper.Raise(propertyName);
        }

        private void CallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(PropertyChangedCount)) return;
            PropertyChangedCount++;
        }
    }
}