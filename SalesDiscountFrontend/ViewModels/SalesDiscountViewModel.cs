using System;
using System.ComponentModel;

namespace SalesDiscountFrontend.ViewModels
{
    internal class SalesDiscountViewModel : INotifyPropertyChanged
    {
        private string iD;
        private string name = null!;
        private string description = null!;
        private bool avavible;

        public string ID
        {
            get => iD;
            set
            {
                iD = value;
                NotifyPropertyChanged("ID");
            }
        }
        public string Name
        {
            get => name; set
            {
                name = value;
                NotifyPropertyChanged("Name");
            }
        }
        public string Description
        {
            get => description; set
            {
                description = value;
                NotifyPropertyChanged("Description");
            }
        }
        public bool Avavible
        {
            get => avavible; set
            {
                avavible = value;
                NotifyPropertyChanged("Avavible");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }
    }
}
