using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public interface IPeopleService
    {
        Person Add(CreatePersonViewModel person);
        Task<PersonLanguage> AddToPerson(string LID, int PID);
        PeopleViewModel All();
        PeopleViewModel FindBy(PeopleViewModel Search);
        Person FindBy(int ID);
        Person Edit(int ID, Person person);
        bool Remove(int ID);
    }
}
