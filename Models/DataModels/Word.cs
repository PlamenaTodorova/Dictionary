using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.DataModels
{
    public enum Gender
    {
        Masculine,
        Feminine,
        Neuter
    }

    public class Word : IComparable<Word>
    {
        public int ID { get; set; }

        public string ForeignWord { get; set; }

        public string Meaning { get; set; }

        public Gender Gender { get; set; }

        public int CompareTo(Word other)
        {
            return this.ForeignWord.CompareTo(other.ForeignWord);
        }
    }
}
