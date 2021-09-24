using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class PeopleViewModel
    {
        public PeopleViewModel()
        {
            
        }
        public List<Person> people = new List<Person>();
        public List<City> AllCities { get; set; } = new List<City>();
        public List<Language> AllLanguages { get; set; } = new List<Language>();
        public string SearchPhrase { get; set; }
        public CreatePersonViewModel CreatePerson { get; set; }
    }
}
