using Models.BindingModels;
using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DataStorage
{
    public class DictionaryController
    {
        private List<Language> languages;
        private LanguageController current;

        public DictionaryController()
        {
            languages = JSONParser<Language>.ReadJson(Constants.FileFolder + Constants.MainFile);
        }

        #region Get

        //Get Languages collection
        public List<Language> GetLanguages()
        {
            return this.languages;
        }

        //Set chosen language
        public void SetLanguage(int id)
        {
            Language selected = languages.FirstOrDefault(e => e.ID == id);

            if (selected != null)
                current = new LanguageController(selected);
            else
                current = null;
        }

        //Get Chosen language
        public ObservableCollection<Word> GetWords()
        {
            return current.GetWords();
        }

        public WordBindingModel GetWord(int id)
        {
            return current.GetWord(id);
        }
        #endregion

        #region Add

        //Add Language
        public void AddLanguage(NewLanguageBindingModel model)
        {
            //Creating the Id
            int newID = GenerateId();

            //Generating the new Language
            Language newLanguage = new Language()
            {
                ID = newID,
                Name = model.Name,
                HasGenders = model.HasGenders
            };

            //Adding it to the bunch
            languages.Add(newLanguage);
            SaveChanges();

            //Setting it as a chosen one
            SetLanguage(newLanguage.ID);
        }

        //Add Word
        public void AddWord(WordBindingModel model)
        {
            current.AddWord(model);
        }

        private void SaveChanges()
        {
            JSONParser<Language>.WriteJson(languages, Constants.FileFolder + Constants.MainFile);
        }

        private int GenerateId()
        {
            if (languages.Count == 0)
                return 0;
            else return languages[languages.Count - 1].ID + 1;
        }
        #endregion

        #region Remove

        //Remove Language

        //Remove Word

        #endregion

        #region Change
        //Change Word
        public void ChangeWord(int id, WordBindingModel model)
        {
            this.current.ChangeWord(id, model);
        }
        #endregion
    }
}
