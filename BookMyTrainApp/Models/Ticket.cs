using System;
using System.Collections.Generic;

#nullable disable

namespace BookMyTrainApp.Models
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public long? Pnrnumber { get; set; }
        public string PassengerName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public int? SeatNumber { get; set; }
        public string Coach { get; set; }
        public string ReservationStatus { get; set; }
        public bool? IsCancelled { get; set; }

        public virtual Pnr PnrnumberNavigation { get; set; }
    }
}
