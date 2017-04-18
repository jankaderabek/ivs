using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Calculator.Model.Entities;

namespace Calculator.ViewModel
{
    public partial class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HistoryItem> historyItemsSource = new ObservableCollection<HistoryItem>();

        public ObservableCollection<HistoryItem> HistoryItemsSource
        {
            get
            {
                return this.historyItemsSource;
            }

            set
            {
                this.historyItemsSource = value;
                OnPropertyChanged();
            }
        }

        private object consoleText;

        public object ConsoleText
        {
            get
            {
                return this.consoleText;
            }

            set
            {
                this.consoleText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
