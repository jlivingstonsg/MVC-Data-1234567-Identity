using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public interface ICityService
    {
        City Add(CreateCityViewModel city);
        CityViewModel All();
        CityViewModel FindBy(CityViewModel Search);
        City FindBy(int ID);
        City Edit(int ID, City city);
        bool Remove(int ID);
    }
}
