namespace BookMyShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public int MovieId { get; set; }

        public int ShowId { get; set; }

        public int TicketId { get; set; }

        [Display(Name = "Total Ticktes")]
        public int TotalTickets { get; set; }

        [Display(Name = "Total Amount")]
        public double TotalAmount { get; set; }

        [Required]
        [Display(Name = "Seat #")]
        public string SeatNumber { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Movie Movie { get; set; }

        public virtual Show Show { get; set; }

        public virtual Ticket Ticket { get; set; }
    }
}
