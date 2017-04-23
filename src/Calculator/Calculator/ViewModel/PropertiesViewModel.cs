using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using Calculator.Model.Entities;

namespace Calculator.ViewModel
{
    /// <summary>
    /// MainViewModel class for calculator app
    /// </summary>
    public partial class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<HistoryItem> historyItemsSource = new ObservableCollection<HistoryItem>();

        /// <summary>
        /// History list
        /// </summary>
        public ObservableCollection<HistoryItem> HistoryItemsSource
        {
            get
            {
                return this.historyItemsSource;
            }

            set
            {
                this.historyItemsSource = new ObservableCollection<HistoryItem>(value.Take(historyLimit).Reverse());
                OnPropertyChanged();
            }
        }

        private object consoleText;

        /// <summary>
        /// Console text
        /// </summary>
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

        private string selectedOperation;

        /// <summary>
        /// Selected operation
        /// </summary>
        public string SelectedOperation
        {
            get
            {
                return selectedOperation; 
                
            }
            set
            {
                selectedOperation = value; 
                OnPropertyChanged();
            }
        }




        /// <summary>
        /// Event for propertyChanged
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// OnPropertyChanged for properties changes
        /// </summary>
        /// <param name="propertyName">property name with change</param>
        protected virtual void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
