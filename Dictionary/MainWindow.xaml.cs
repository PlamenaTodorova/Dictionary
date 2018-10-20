using DataStorage;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DictionaryController controller;

        public MainWindow()
        {
            //Setting the dictionaryController
            this.controller = new DictionaryController();

            SettingBasics();
        }

        public MainWindow(DictionaryController controller)
        {
            //Setting the dictionaryController
            this.controller = controller;

            SettingBasics();
        }

        public void SettingBasics()
        {
            InitializeComponent();

            this.pickLanguage.ItemsSource = controller.GetLanguages();
            this.pickLanguage.SelectedIndex = 0;
        }

        private void NewLanguage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void NewLanguage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            AddLanguage window = new AddLanguage();
            window.ShowDialog();

            if (window.DialogResult == true)
            {
                NewLanguageBindingModel newLanguage = window.NewLanguage;

                //Add language
                controller.AddLanguage(newLanguage);

                //Redirect to ViewWords
                OpenDisplay();
            }
        }

        private void OpenDisplay()
        {
            DisplayWords display = new DisplayWords(controller);

            display.Show();

            this.Close();
        }

        private void ShowDictionary_Click(object sender, RoutedEventArgs e)
        {
            int id = (int)pickLanguage.SelectedValue;
            controller.SetLanguage(id);

            OpenDisplay();
        }

        private void WordOfTheDay_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
