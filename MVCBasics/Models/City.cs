using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public Country Country { get; set; }
        public List<Person> People { get; set; } = new List<Person>();
        public override string ToString()
        {
            return Name;
        }
    }
}
