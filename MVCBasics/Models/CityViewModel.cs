using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CityViewModel
    {
        public List<City> Cities = new List<City>();
        public List<Country> Countries { get; set; } = new List<Country>();
        public string SearchPhrase;
        public CreateCityViewModel CreateCity { get; set; }
    }
}
