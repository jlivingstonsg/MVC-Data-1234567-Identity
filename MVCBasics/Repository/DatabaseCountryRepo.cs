using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public class DatabaseCountryRepo : ICountryRepo
    {
        PeopleContext _DB;
        public DatabaseCountryRepo(PeopleContext _DB)
        {
            this._DB = _DB;
        }
        public Country Create(string Name)
        {
            Country c = new Country();
            c.Name = Name;
            _DB.Country.Add(c);
            _DB.SaveChanges();
            return c;
        }

        public bool Delete(Country country)
        {
            if (_DB.Country.Contains(country))
            {
                var cities = _DB.City.Where(city => city.Country == country).ToList();
                foreach(var city in cities)
                {
                    var people = _DB.People.Where(person => person.City == city).ToList();
                    _DB.RemoveRange(people);
                }
                _DB.RemoveRange(cities);
                _DB.Country.Remove(country);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }

        public List<Country> Read()
        {
            return _DB.Country.AsParallel().ToList();
        }

        public Country Read(int ID)
        {
            return _DB.Country.Include(city => city.City).FirstOrDefault(country => country.ID == ID);
        }

        public Country Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
