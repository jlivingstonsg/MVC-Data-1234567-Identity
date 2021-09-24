using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public int PhoneNumber { get; set; }
        public City City { get; set; }
        public List<PersonLanguage> Languages { get; set; } = new List<PersonLanguage>();
        public override string ToString()
        {
            return Name;
        }
    }
}
