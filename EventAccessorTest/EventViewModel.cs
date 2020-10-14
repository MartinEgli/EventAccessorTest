using System.Windows.Input;

namespace EventAccessorTest
{
    public class EventViewModel : BindableBase
    {
        public InnerViewModel1 Inner { get; set; }

        public string Text => Inner.Text;

        public ICommand Command { get; set; }

        public EventViewModel()
        {
            Inner = new InnerViewModel1();
            Command = new RelayCommand((_) => Inner.Publish());
            Inner.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);
        }
    }
}