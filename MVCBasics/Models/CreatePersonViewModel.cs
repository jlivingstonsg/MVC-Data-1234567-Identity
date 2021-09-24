using MVCBasics.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CreatePersonViewModel
    {
        public CreatePersonViewModel()
        {
            Model = new Person();
        }
        Person model;
        public Person Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
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
        [Required(ErrorMessage = "Please Enter Your Full Name")]
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
        [Required(ErrorMessage = "Please Enter Your Mobile No")]
        [RegularExpression(@"[0-9]*", ErrorMessage = "Only Letters Allowed")]
        public int PhoneNumber
        {
            get
            {
                return Model.PhoneNumber;
            }
            set
            {
                Model.PhoneNumber = value;
            }
        }
        [Required]
        public City City
        {
            get
            {
                return Model.City;
            }
            set
            {
                Model.City = value;
            }
        }
        public List<PersonLanguage> Languages
        {
            get
            {
                return Model.Languages;
            }
            set
            {
                Model.Languages = value;
            }
        }
    }
}
