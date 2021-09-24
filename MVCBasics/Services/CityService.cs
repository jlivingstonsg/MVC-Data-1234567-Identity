using MVCBasics.Models;
using MVCBasics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public class CityService : ICityService
    {
        ICityRepo CityDatabase;
        public CityService(ICityRepo _CityDatabase)
        {
            CityDatabase = _CityDatabase;
        }
        public City Add(CreateCityViewModel city)
        {
            return CityDatabase.Create(city.Name,city.Country);
        }
        CityViewModel CVM = new CityViewModel();
        public CityViewModel All()
        {
            CVM.Cities = CityDatabase.Read();
            return CVM;
        }

        public City Edit(int ID, City city)
        {
            throw new NotImplementedException();
        }

        public CityViewModel FindBy(CityViewModel Search)
        {
            string[] parameters = Search.SearchPhrase.Split(new char[' ']);
            var cities = CityDatabase.Read();
            CVM.Cities = cities.Where(city => parameters.Any(param =>
                city.Name.Contains(param)||
                city.Country.Name.Contains(param)
                )).ToList();
            return CVM;
        }

        public City FindBy(int ID)
        {
            return CityDatabase.Read(ID);
        }

        public bool Remove(int ID)
        {
            var cities = CityDatabase.Read();
            var city = cities.Where(p => p.ID == ID).FirstOrDefault();
            return CityDatabase.Delete(city);
        }
    }
}
