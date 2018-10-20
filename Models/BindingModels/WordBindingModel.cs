using Models.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BindingModels
{
    public class WordBindingModel : INotifyPropertyChanged
    {
        private string foraignWord;
        private string meaning;
        private Gender gender;
        
        public string ForaignWord
        {
            get { return this.foraignWord; }
            set
            {
                if (this.foraignWord != value)
                {
                    this.foraignWord = value;
                    this.NotifyPropertyChanged("ForaignWord");
                }
            }
        }

        public string Meaning
        {
            get { return this.meaning; }
            set
            {
                if (this.meaning != value)
                {
                    this.meaning = value;
                    this.NotifyPropertyChanged("Meaning");
                }
            }
        }

        public Gender Gender
        {
            get { return this.gender; }
            set
            {
                if (this.gender != value)
                {
                    this.gender = value;
                    this.NotifyPropertyChanged("GenderIndex");
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
