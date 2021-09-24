using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CreateLanguageViewModel
    {
        public Language Model { get; set; } = new Language();
        public int ID
        {
            get
            {
                return Model.ID;
            }
            set
            {
                Model.ID = value;
            }
        }
        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
            }
        }
        public List<PersonLanguage> People
        {
            get
            {
                return Model.People;
            }
            set
            {
                Model.People = value;
            }
        }
    }
}
