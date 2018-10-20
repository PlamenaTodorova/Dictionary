using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BindingModels
{
    public class NewLanguageBindingModel : INotifyPropertyChanged
    {
        private string name;
        private bool hasGenders;

        public NewLanguageBindingModel()
        {
            HasGenders = true;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public bool HasGenders
        {
            get { return this.hasGenders; }
            set
            {
                if (this.hasGenders != value)
                {
                    this.hasGenders = value;
                    this.NotifyPropertyChanged("HasGenders");
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
