using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BookMyTrainAdminClientApp.Models
{
    public partial class Fare
    {
        [DisplayName("Coach Type")]
        public string TypeOfCoach { get; set; }
        [DisplayName("Fare Per Kilometer")]
        [DataType(DataType.Currency)]
        public decimal? Fare1 { get; set; }
    }
}
