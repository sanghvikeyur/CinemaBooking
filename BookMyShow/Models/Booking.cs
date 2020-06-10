namespace BookMyShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Booking")]
    public partial class Booking
    {
        public int BookingId { get; set; }

        public int MovieId { get; set; }

        public int ShowId { get; set; }

        [Required]
        public string SeatNumber { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Show Show { get; set; }
    }
}
