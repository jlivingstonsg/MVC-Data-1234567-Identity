using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public class DatabaseCityRepo : ICityRepo
    {
        PeopleContext _DB;
        public DatabaseCityRepo(PeopleContext _DB)
        {
            this._DB = _DB;
        }
        public City Create(string Name, Country country)
        {
            City c = new City();
            c.Name = Name;
            _DB.Country.FirstOrDefault(c => c.Name == country.Name).City.Add(c);
            _DB.City.Add(c);
            _DB.SaveChanges();
            return c;
        }

        public bool Delete(City city)
        {
            if (_DB.City.Contains(city))
            {
                var people = _DB.People.Where(people => people.City == city).ToList();
                _DB.RemoveRange(people);
                _DB.City.Remove(city);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }

        public List<City> Read()
        {
            return _DB.City.Include(city => city.Country).AsParallel().ToList();
        }

        public City Read(int ID)
        {
            return _DB.City.Include(city=>city.People).Include(city => city.Country).FirstOrDefault(city => city.ID == ID);
        }

        public City Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}
