using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStorage
{
    public class JSONParser<T>
    {
        //Reading a Json file
        public static List<T> ReadJson(string filePath)
        {
            List<T> collection = new List<T>();
            int attemtps = 5;

            for (int i = 0; i < attemtps; i++)
            {
                try
                {
                    string json = File.ReadAllText(filePath);
                    collection = JsonConvert.DeserializeObject<List<T>>(json);

                    if (collection == null)
                        return new List<T>();

                    return collection;
                }
                catch (Exception)
                {
                    continue;
                }
            }

            //Should reach here only on first run when there is no folder Files
            Directory.CreateDirectory(Directory.GetCurrentDirectory() + @"\Files");

            collection = new List<T>();

            WriteJson(collection, filePath);

            return collection;
        }

        //Writing a Json file
        public static void WriteJson(List<T> collection, string filePath)
        {
            string text = JsonConvert.SerializeObject(collection);

            File.WriteAllText(filePath, text);
        }
    }
}
