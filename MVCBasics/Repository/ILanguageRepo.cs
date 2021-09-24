using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public interface ILanguageRepo
    {
        Language Create(string Name);
        PersonLanguage AddToPerson(int language, Person person);
        Task<List<Language>> Read();
        Language Read(int ID);
        Language Update(Language language);
        bool Delete(Language language);
    }
}
