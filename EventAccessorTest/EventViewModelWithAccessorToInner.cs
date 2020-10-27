using System.ComponentModel;
using System.Windows.Input;

namespace EventAccessorTest
{
    public class EventViewModelWithAccessorToInner : INotifyPropertyChanged
    {
        public InnerViewModel1 Inner { get; set; }

        public string Text => Inner.Text;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => Inner.PropertyChanged += value;
            remove => Inner.PropertyChanged -= value;
        }

        public ICommand Command { get; set; }

        public EventViewModelWithAccessorToInner()
        {
            Inner = new InnerViewModel1();
            Command = new RelayCommand((_) => Inner.Publish());
            PropertyChanged += CallPropertyChanged;
        }

        private void CallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}