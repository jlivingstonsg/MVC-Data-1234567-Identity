using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CreateCountryViewModel
    {
        public CreateCountryViewModel()
        {
            //Model = new Country();
        }
        Country _Model;
        public Country Model { get; set; } = new Country();
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
        public List<City> City
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
    }
}
