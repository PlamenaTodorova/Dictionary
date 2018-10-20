using Models.BindingModels;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for AddWord.xaml
    /// </summary>
    public partial class AddWord : Window
    {
        private WordBindingModel model;

        public AddWord()
        {
            InitializeComponent();

            //Binding the created word
            model = new WordBindingModel();
            this.DataContext = model;
        }

        private void AddWord_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                this.DialogResult = true;
            }
        }

        private bool IsValid()
        {
            if (model.Meaning != null && model.ForaignWord != null && 
                    model.Meaning.Length > 0 && model.ForaignWord.Length > 0)
                return true;

            return false;
        }

        public WordBindingModel newWord { get { return model; } }
    }
}
