using Models.BindingModels;
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
    /// Interaction logic for AddLanguage.xaml
    /// </summary>
    public partial class AddLanguage : Window
    {
        public AddLanguage()
        {
            InitializeComponent();

            //Setting the binding model
            this.NewLanguage = new NewLanguageBindingModel();
            this.DataContext = this.NewLanguage;
        }

        public NewLanguageBindingModel NewLanguage { get; private set; }

        private void AddLanguage_Click(object sender, RoutedEventArgs e)
        {
            if (this.NewLanguage.Name.Length > 0)
            {
                this.DialogResult = true;
            }
        }
    }
}
