using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public interface ICountryRepo
    {
        Country Create(string Name);
        List<Country> Read();
        Country Read(int ID);
        Country Update(Country country);
        bool Delete(Country country);
    }
}
