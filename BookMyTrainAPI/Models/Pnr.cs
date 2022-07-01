using System;
using System.Collections.Generic;

#nullable disable

namespace BookMyTrainAPI.Models
{
    public partial class Pnr
    {
        public Pnr()
        {
            Tickets = new HashSet<Ticket>();
        }

        public long Pnrnumber { get; set; }
        public int? UserId { get; set; }
        public DateTime? JourneyDate { get; set; }
        public string JourneyStartTime { get; set; }
        public string JourneyEndTime { get; set; }
        public int? NumberOfPassengers { get; set; }
        public decimal? TotalFare { get; set; }
        public bool? IsDeleted { get; set; }
        public int? TransactionId { get; set; }
        public string FromStation { get; set; }
        public string ToStation { get; set; }
        public string BoardingStation { get; set; }
        public int? TrainNumber { get; set; }
        public string TypeOfCoach { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
