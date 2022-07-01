using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
#nullable disable

namespace BookMyTrainAdminClientApp.Models
{
    public partial class Reach
    {
        public int Id { get; set; }
        [DisplayName("Train Number")]
        [Required(ErrorMessage = "Required")]
        public int? TrainNumber { get; set; }
        [DisplayName("Station")]
        [Required(ErrorMessage = "Required")]
        public string StationCode { get; set; }
        [DisplayName("Arrival Time")]
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Required")]
        public string ArrivalTime { get; set; }
        [DisplayName("Station Name")]
        public virtual Station StationCodeNavigation { get; set; }
        [DisplayName("Train Name")]
        public virtual Train TrainNumberNavigation { get; set; }
    }
}
