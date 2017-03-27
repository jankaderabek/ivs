using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Calculator.ViewModel
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> historyItemsSource = new ObservableCollection<string>();

        public ObservableCollection<string> HistoryItemsSource
        {
            get
            {
                return this.historyItemsSource;
            }

            set
            {
                this.historyItemsSource = value;
                OnPropertyChanged("HistoryItemsSource");
            }
        }

        private string consoleText = string.Empty;

        public string ConsoleText
        {
            get
            {
                return this.consoleText;
            }

            set
            {
                this.consoleText = value;
                OnPropertyChanged("ConsoleText");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
