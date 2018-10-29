using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BindingModels
{
    public class SearchBindingModel : INotifyPropertyChanged
    {
        private string toSearch;

        public string ToSearch
        {
            get { return this.toSearch; }
            set
            {
                if (this.toSearch != value)
                {
                    this.toSearch = value;
                    this.NotifyPropertyChanged("ToSearch");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

    }
}
