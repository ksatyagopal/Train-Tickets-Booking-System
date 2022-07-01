using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyTrainApp.Models
{
    public class Verify
    {
        [DisplayName("Enter OTP")]
        [Required]
        [DataType(DataType.Text)]
        [StringLength(6,ErrorMessage = "Not a Valid OTP")]
        public string OTP { set; get; }
    }
}
