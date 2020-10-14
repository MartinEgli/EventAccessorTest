using System.ComponentModel;
using System.Runtime.CompilerServices;
using EventAccessorTest.Annotations;

namespace EventAccessorTest
{
    public class InnerViewModel3 : INotifyPropertyChanged
    {
        private readonly ViewModel3 _parent;

        private int _index;

        private string _text = "InnerViewModel";

        public InnerViewModel3(ViewModel3 parent)
        {
            _parent = parent;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public int Index
        {
            get => _index;
            set
            {
                if (value == _index) return;
                _index = value;
                OnPropertyChanged();
            }
        }

        public string Text
        {
            get => _text;
            set
            {
                if (value == _text) return;
                _text = value;
                OnPropertyChanged();
            }
        }
        public void Publish()
        {
            Index++;
            Text = "InnerViewModel" + Index;
        }
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(_parent, new PropertyChangedEventArgs(propertyName));
        }
    }
}