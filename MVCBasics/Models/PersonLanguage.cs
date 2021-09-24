using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class PersonLanguage
    {
        [Key]
        public int ID { get; set; }
        public int PersonID { get; set; }
        public Person Person { get; set; }
        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}
