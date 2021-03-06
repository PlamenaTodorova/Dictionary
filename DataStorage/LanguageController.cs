using Models.BindingModels;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace DataStorage
{
    public class LanguageController
    {
        private Language languageInfo;
        private List<Word> words;
        private ObservableCollection<Word> views;

        public LanguageController(Language language)
        {
            if (language != null)
            {
                this.languageInfo = language;
                this.words = JSONParser<Word>.ReadJson(Constants.FileFolder + this.languageInfo.ID + Constants.Extension);
                this.views = new ObservableCollection<Word>(this.words);
            }
            else
            {
                throw new ArgumentException("Language is not valid.");
            }
        }

        private void SaveChanges()
        {
            JSONParser<Word>.WriteJson(words, Constants.FileFolder + this.languageInfo.ID + Constants.Extension);
        }

        #region Get

        //Get Chosen language
        public ObservableCollection<Word> GetWords()
        {
            return views;
        }
        #endregion

        #region Add

        //Add Word
        internal void AddWord(WordBindingModel model)
        {
            Word newWord = new Word()
            {
                ID = GenerateId(),
                ForeignWord = model.ForaignWord,
                Meaning = model.Meaning,
                Gender = model.Gender
            };

            words.Add(newWord);

            words.Sort();

            HelperFunctions.PutInTheRightPlace(views, newWord);
            SaveChanges();
        }

        private int GenerateId()
        {
            if (words.Count == 0)
                return 0;
            else return words[words.Count - 1].ID + 1;
        }

        #endregion

        #region Remove

        //Remove Word

        #endregion

        #region Change
        //Change Word

        #endregion
    }
}
