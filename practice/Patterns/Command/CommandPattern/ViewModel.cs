using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Epam.NetMentoring.CommandPattern
{
    public class ViewModel:INotifyPropertyChanged
    {
        private string _text;
        private ObservableCollection<ICommand> _menu = new ObservableCollection<ICommand>();

        private void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public string Text
        {
            get { return _text; }
            set
            {
                _text = value;
                this.OnPropertyChanged("Text");
            }
        }

        public ObservableCollection<ICommand> Menu
        {
            get { return _menu; }
            set
            {
                _menu = value;
                this.OnPropertyChanged("Menu");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
