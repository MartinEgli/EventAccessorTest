using System.ComponentModel;
using System.Windows.Input;

namespace EventAccessorTest
{
    public class EventViewModelWithAccessorToInnerAndParentAsSender : INotifyPropertyChanged
    {
        public InnerViewModel3 Inner { get; set; }

        public string Text => Inner.Text;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => Inner.PropertyChanged += value;
            remove => Inner.PropertyChanged -= value;
        }

        public ICommand Command { get; set; }

        public EventViewModelWithAccessorToInnerAndParentAsSender()
        {
            Inner = new InnerViewModel3(this);
            Command = new RelayCommand((_) => Inner.Publish());
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}