using System.ComponentModel;
using System.Windows.Input;

namespace EventAccessorTest
{
    public class ViewModel1 : INotifyPropertyChanged
    {
        public InnerViewModel1 Inner { get; set; }

        public string Text => Inner.Text;

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => Inner.PropertyChanged += value;
            remove => Inner.PropertyChanged -= value;
        }

        public ICommand Command { get; set; }

        public ViewModel1()
        {
            Command = new RelayCommand((_) => Inner.Publish());
            Inner = new InnerViewModel1();
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}