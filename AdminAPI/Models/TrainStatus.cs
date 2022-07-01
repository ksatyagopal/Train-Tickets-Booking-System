using System;
using System.Collections.Generic;

#nullable disable

namespace AdminAPI.Models
{
    public partial class TrainStatus
    {
        public int tsId { get; set; }
        public DateTime? Doj { get; set; }
        public int? TrainNumber { get; set; }
        public int? AcSeats1Booked { get; set; }
        public int? AcSeats2Booked { get; set; }
        public int? AcSeats3Booked { get; set; }
        public int? SlSeatsBooked { get; set; }
        public int? SsSeatsBooked { get; set; }
        public int? AcSeats1Available { get; set; }
        public int? AcSeats2Available { get; set; }
        public int? AcSeats3Available { get; set; }
        public int? SlSeatsAvailable { get; set; }
        public int? SsSeatsAvailable { get; set; }

        public virtual Train TrainNumberNavigation { get; set; }
    }
}
