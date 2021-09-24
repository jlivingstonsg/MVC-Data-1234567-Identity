using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public interface ICityRepo
    {
        City Create(string Name, Country country);
        List<City> Read();
        City Read(int ID);
        City Update(City city);
        bool Delete(City city);
    }
}
