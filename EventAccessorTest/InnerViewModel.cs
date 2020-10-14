namespace EventAccessorTest
{
    public class InnerViewModel1 : BindableBase
    {
        private string _text = "InnerViewModel";
        private int _index;

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

        public void Publish()
        {
            Index++;
            Text = "InnerViewModel" + Index;
        }
    }
}