using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class LanguageViewModel
    {
        public List<Language> Languages = new List<Language>();
        public List<Person> AllPeople { get; set; } = new List<Person>();
        public string SearchPhrase { get; set; }
        public CreateLanguageViewModel CreateLanguage { get; set; }
    }
}
