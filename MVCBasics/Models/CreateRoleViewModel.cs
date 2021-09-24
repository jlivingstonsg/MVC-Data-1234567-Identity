using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCBasics.Models
{
    public class CreateRoleViewModel
    {
        public string ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<User> RoleUsers { get; set; } = new List<User>();
    }
}
