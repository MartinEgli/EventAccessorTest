﻿using System.ComponentModel;
using System.Windows.Input;

namespace EventAccessorTest
{
    public class EventViewModelWithAccessorToInnerAndParentAsSender : INotifyPropertyChanged
    {
        public EventViewModelWithAccessorToInnerAndParentAsSender()
        {
            Inner = new InnerViewModel3(this);
            Command = new RelayCommand(_ => Inner.Publish());
            PropertyChanged += CallPropertyChanged;
        }

        public InnerViewModel3 Inner { get; set; }

        public string Text => Inner.Text;

        public ICommand Command { get; set; }

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => Inner.PropertyChanged += value;
            remove => Inner.PropertyChanged -= value;
        }

        private void CallPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}