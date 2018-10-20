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
using System.Windows.Shapes;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for DisplayWords.xaml
    /// </summary>
    public partial class DisplayWords : Window
    {
        private DictionaryController controller;

        public DisplayWords(DictionaryController controller)
        {
            this.controller = controller;

            InitializeComponent();

            pickLanguage.ItemsSource = controller.GetLanguages();
            words.ItemsSource = controller.GetWords();
        }

        private void BackToStartMenu_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(controller);
            window.Show();
            this.Close();
        }

        private void AddWord_Click(object sender, RoutedEventArgs e)
        {
            AddWord addWord = new AddWord();

            addWord.ShowDialog();

            if (addWord.DialogResult == true)
            {
                WordBindingModel model = addWord.newWord;

                //Add to the collection
                controller.AddWord(model);

                //Refresh the collection
                words.ItemsSource = controller.GetWords();
            }
        }

        private void LanguageSelected(object sender, SelectionChangedEventArgs e)
        {
            if (pickLanguage.SelectedValue != null)
            {
                int id = (int)pickLanguage.SelectedValue;

                controller.SetLanguage(id);

                pickLanguage.ItemsSource = controller.GetLanguages();
                words.ItemsSource = controller.GetWords();
            }
        }
    }
}

