using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentWPF2.Models
{
    public class SearchDictionary
    {
        private HashSet<string> wordsDict = new HashSet<string>();

        public void AddWord (string word)
        {
            wordsDict.Add(word.ToLower());
        }

        public void Clear()
        {
            wordsDict.Clear();
        }

        public  WordData GetParsedWord (string word)
        {
            string wordLeft = word;
            var res = new WordData();
            res.Name = word;
            StringBuilder curPartOfWord = new StringBuilder( word);

            while (curPartOfWord.Length > 0)
            {
                if (curPartOfWord.Length == word.Length)
                { 
                    curPartOfWord.Length--;
                    continue;
                }

                var curStringPart = curPartOfWord.ToString();
                if (WordsDict.Contains(curStringPart.ToLower()))
                {
                    res.AddSubWord(curStringPart);
                    curPartOfWord = new StringBuilder(wordLeft).Remove(0, curStringPart.Length);
                    wordLeft = curPartOfWord.ToString();
                    continue;
                }
                curPartOfWord.Length--;
            }

            return res;
        }

        public HashSet<string> WordsDict => wordsDict;

       

    }
}
