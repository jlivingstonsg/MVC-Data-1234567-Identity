using Microsoft.EntityFrameworkCore;
using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Repository
{
    public class DatabaseLanguageRepo : ILanguageRepo
    {
        PeopleContext _DB;
        public DatabaseLanguageRepo(PeopleContext _DB)
        {
            this._DB = _DB;
        }
        public Language Create(string Name)
        {
            Language L = new Language();
            L.Name = Name;
            _DB.Language.Add(L);
            _DB.SaveChanges();
            return L;
        }
        public PersonLanguage AddToPerson(int languageID,Person person)
        {
            PersonLanguage p = new PersonLanguage();
            p.LanguageID = languageID;
            p.PersonID = person.ID;
            _DB.PersonLanguage.Add(p);
            _DB.SaveChanges();
            return p;
        }
        public bool Delete(Language language)
        {
            if (_DB.Language.Contains(language))
            {
                _DB.Language.Remove(language);
                _DB.SaveChanges();
                return true;
            }
            return false;
        }

        public async Task<List<Language>> Read()
        {
            return await _DB.Language.ToListAsync();
        }

        public Language Read(int ID)
        {
            var D = _DB.Language.Include(l=>l.People).FirstOrDefault(l=>l.ID==ID);
            Language L = new Language();
            L.Name = D.Name;
            foreach(var d in D.People)
            {
                d.Person = _DB.People.FirstOrDefault(p => p.ID == d.PersonID);
                L.People.Add(d);
            }
            return L;
        }

        public Language Update(Language language)
        {
            throw new NotImplementedException();
        }
    }
}
