using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public interface ICountryService
    {
        Country Add(CreateCountryViewModel country);
        CountryViewModel All();
        CountryViewModel FindBy(CountryViewModel Search);
        Country FindBy(int ID);
        Country Edit(int ID, Country country);
        bool Remove(int ID);
    }
}
