using MVCBasics.Models;
using MVCBasics.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Services
{
    public class LanguageService : ILanguageService
    {
        ILanguageRepo LanguageDatabase;
        private readonly IPeopleRepo PeopleDatabase;

        public LanguageService(ILanguageRepo _LanguageDatabase,IPeopleRepo PeopleDatabase)
        {
            LanguageDatabase = _LanguageDatabase;
            this.PeopleDatabase = PeopleDatabase;
        }
        public Language Add(CreateLanguageViewModel language)
        {
            return LanguageDatabase.Create(language.Name);
        }
        public PersonLanguage AddToPerson(int LID,string PersonName)
        {
            var AllPeople = PeopleDatabase.Read();
            var person = AllPeople.FirstOrDefault(per => per.Name == PersonName);
            return LanguageDatabase.AddToPerson(LID, person);
        }
        LanguageViewModel LVM = new LanguageViewModel();
        public async Task<LanguageViewModel> All()
        {
            LVM.Languages = await LanguageDatabase.Read();
            return LVM;
        }

        public Language Edit(int ID, Language person)
        {
            throw new NotImplementedException();
        }

        public LanguageViewModel FindBy(LanguageViewModel Search)
        {
            throw new NotImplementedException();
        }

        public Language FindBy(int ID)
        {
            return LanguageDatabase.Read(ID);
        }

        public async Task<bool> Remove(int ID)
        {
            var languages = await LanguageDatabase.Read();
            var language = languages.Where(p => p.ID == ID).FirstOrDefault();
            return LanguageDatabase.Delete(language);
        }
    }
}
