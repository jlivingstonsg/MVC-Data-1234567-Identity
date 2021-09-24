using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CreateCityViewModel
    {
        public CreateCityViewModel()
        {
            //Null Error On City Creation
            //Model = new City();
        }
        //City _Model;
        public City Model { get; set; } = new City();
        //{
        //    get
        //    {
        //        return _Model;
        //    }
        //    set
        //    {
        //        _Model = Model;
        //    }
        //}
        [Required]
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
        [Required(ErrorMessage = "Please Enter City Name")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Only Letters Allowed")]
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
        public Country Country
        {
            get
            {
                return Model.Country;
            }
            set
            {
                Model.Country = value;
            }
        }
        public List<Person> People
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
