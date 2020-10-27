using System.ComponentModel;
using System.Windows.Input;

namespace EventAccessorTest
{
    public class EventViewModelWithEventHandlerMapperToInner : INotifyPropertyChanged
    {
        private readonly PropertyChangedEventHandlerMapper _propertyChangedChangedEventHandlerMapper;

        public EventViewModelWithEventHandlerMapperToInner()
        {
            Inner = new InnerViewModel1();
            Command = new RelayCommand(_ => Inner.Publish());

            _propertyChangedChangedEventHandlerMapper = new PropertyChangedEventHandlerMapper(
                handler => Inner.PropertyChanged += handler,
                handler => Inner.PropertyChanged -= handler,
                this);

            PropertyChanged += OnPropertyChanged;
            PropertyChanged += OnPropertyChanged;
            PropertyChanged += OnPropertyChanged;
        }

        public ICommand Command { get; set; }
        public InnerViewModel1 Inner { get; set; }

        public string Text => Inner.Text;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _propertyChangedChangedEventHandlerMapper.Add(value);
            remove => _propertyChangedChangedEventHandlerMapper.Remove(value);
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}