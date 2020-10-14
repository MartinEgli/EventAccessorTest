using System.Windows.Input;

namespace EventAccessorTest
{
    public class ViewModel2 : BindableBase
    {
        public InnerViewModel1 Inner { get; set; }

        public string Text => Inner.Text;

        public ICommand Command { get; set; }

        public ViewModel2()
        {
            Command = new RelayCommand((_) => Inner.Publish());
            Inner = new InnerViewModel1();
            Inner.PropertyChanged += (sender, args) => OnPropertyChanged(args.PropertyName);
        }

    }
}