using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Translator.Models
{
    public class Translator
    {
        public readonly Dictionary<string, string> _dictionary;


        public Translator(string path)
        {
            _dictionary = ReadDict(path);
        }

        private Dictionary<string, string> ReadDict(string path)
        {
            var dict = new Dictionary<string, string>();
            using (var sr = new StreamReader(path))
            {
                string line = null;

                while ((line = sr.ReadLine()) != null)
                {
                    var pair = line.Split(":");
                    dict.Add(pair[0], pair[1]);
                }
            }
            return dict;
        }

        public string Transalte(string searchWord)
        {

            if (_dictionary.ContainsKey(searchWord))
            {
                return _dictionary.FirstOrDefault(x => x.Key == searchWord).Value;
            }
            else if (_dictionary.ContainsValue(searchWord))
            {
                return _dictionary.FirstOrDefault(x => x.Value == searchWord).Key;
            }
            return String.Empty;
        }
    }
}
