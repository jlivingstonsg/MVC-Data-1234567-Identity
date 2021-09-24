using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CountryViewModel
    {
        public List<Country> Countries = new List<Country>();
        public string SearchPhrase;
        public CreateCountryViewModel CreateCountry { get; set; }
    }
}
