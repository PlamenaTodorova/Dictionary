using Models.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public static class HelperFunctions
    {
        public static void PutInTheRightPlace(ObservableCollection<Word> collection, Word element)
        {
            int place = FindRightPlace(collection, element);

            collection.Insert(place, element);
        }

        private static int FindRightPlace(ObservableCollection<Word> collection, Word element)
        {
            int start = 0;
            int end = collection.Count - 1;

            while (start <= end)
            {
                int mid = (start + end) / 2;

                if (collection[mid].CompareTo(element) > 0)
                    end = mid - 1;
                else
                    start = mid + 1;
            }

            return start;
        }
    }
}
