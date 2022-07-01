using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookMyTrainAdminClientApp.Models
{
    public class Password
    {
        [DisplayName("New Password")]
        [Required]
        [DataType(DataType.Password)]
        public string password { set; get; }
        [DisplayName("Re-Enter New Password")]
        [Required]
        [Compare("password", ErrorMessage ="Both passwords should match")]
        [DataType(DataType.Password)]
        public string confirmPassword { set; get; }
    }
}
