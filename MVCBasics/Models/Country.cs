using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<City> City { get; set; } = new List<City>();
        public override string ToString()
        {
            return Name;
        }
    }
}
