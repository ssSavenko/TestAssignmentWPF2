using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAssignmentWPF2.Models
{
    public class WordData
    {
        private string name;
        private List<string> nameParts = new List<string>();

        public string Name { get => name; set => name = value; }

        public string NameParts
        {
            get
            {
                StringBuilder resString = new StringBuilder("") ;
                foreach (var item in nameParts)
                    resString.Append( $"{item} ");
                return resString.ToString();
            } 
        }

        public void AddSubWord(string subWord)
        {
            nameParts.Add(subWord);
        }


        public List<string> NamePartsList { get => nameParts; set => nameParts = value; }
    }
}
