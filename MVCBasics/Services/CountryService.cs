using MVCBasics.Models;
using MVCBasics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public class CountryService : ICountryService
    {
        ICountryRepo CountryDatabase;
        public CountryService(ICountryRepo _CountryDatabase)
        {
            CountryDatabase = _CountryDatabase;
        }
        public Country Add(CreateCountryViewModel country)
        {
            return CountryDatabase.Create(country.Name);
        }
        CountryViewModel CVM = new CountryViewModel();
        public CountryViewModel All()
        {
            CVM.Countries = CountryDatabase.Read();
            return CVM;
        }

        public Country Edit(int ID, Country country)
        {
            throw new NotImplementedException();
        }

        public CountryViewModel FindBy(CountryViewModel Search)
        {
            string[] parameters = Search.SearchPhrase.Split(new char[' ']);
            var countries = CountryDatabase.Read();
            CVM.Countries = countries.Where(country => parameters.Any(param =>
                country.Name.Contains(param)
                )).ToList();
            return CVM;
        }

        public Country FindBy(int ID)
        {
            return CountryDatabase.Read(ID);
        }

        public bool Remove(int ID)
        {
            var countries = CountryDatabase.Read();
            var country = countries.Where(p => p.ID == ID).FirstOrDefault();
            return CountryDatabase.Delete(country);
        }
    }
}
