using DataStorage;
using Models.BindingModels;
using System.Windows;
using System.Windows.Controls;

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for DisplayWords.xaml
    /// </summary>
    public partial class DisplayWords : Window
    {
        private DictionaryController controller;
        private SearchBindingModel search;

        public DisplayWords(DictionaryController controller)
        {
            this.controller = controller;
            this.search = new SearchBindingModel();

            InitializeComponent();

            pickLanguage.ItemsSource = controller.GetLanguages();
            searchBar.DataContext = search;
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
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            string stringId =
                ((TextBlock)
                ((Grid)
                ((Border)
                (((StackPanel)
                ((Button)sender).Parent).Parent)).Parent).Children[0]).Text;

            int id = int.Parse(stringId);

            WordBindingModel model = controller.GetWord(id);

            EditWord window = new EditWord(model);

            window.ShowDialog();

            if (window.DialogResult == true)
            {
                model = window.newWord;

                //Edit the word
                controller.ChangeWord(id, model);
            }
        }

        private void Remove_Click(object sender, RoutedEventArgs e)
        {
            string stringId =
                ((TextBlock)
                ((Grid)
                ((Border)
                (((StackPanel)
                ((Button)sender).Parent).Parent)).Parent).Children[0]).Text;

            int id = int.Parse(stringId);

            controller.RemoveWord(id);
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            words.ItemsSource = controller.GetWords(search.ToSearch);
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
