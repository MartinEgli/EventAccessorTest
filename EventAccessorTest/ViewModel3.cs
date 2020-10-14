using System.ComponentModel;
using System.Windows.Input;

namespace EventAccessorTest
{
    public class ViewModel3 : INotifyPropertyChanged
    {
        public InnerViewModel3 Inner { get; set; }

        public string Text => Inner.Text;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => Inner.PropertyChanged += value;
            remove => Inner.PropertyChanged -= value;
        }

        public ICommand Command { get; set; }

        public ViewModel3()
        {
            Command = new RelayCommand((_) => Inner.Publish());
            Inner = new InnerViewModel3(this);
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}