using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public interface IPeopleRepo
    {
        Person Create(string Name, int PhoneNumber, City City);
        Task<PersonLanguage> AddToPerson(Language language, int person);
        List<Person> Read();
        Person Read(int ID);
        Person Update(Person person);
        bool Delete(Person person);
    }
}
