using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyTrainApp.Models
{
    public class SearchTrains
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("From")]
        public string From { get; set; }
        [DisplayName("To")]
        public string To { get; set; }
        [DisplayName("Journey Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime JDate { set; get; }
    }
}
