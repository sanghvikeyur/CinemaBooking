namespace BookMyShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ticket()
        {
            Orders = new HashSet<Order>();
        }

        public int TicketId { get; set; }

        public int ShowId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ticket Type")]
        public string TicketType { get; set; }

        [Display(Name = "Total Seats")]
        public int TotalSeats { get; set; }

        public int Price { get; set; }

        public int MovieId { get; set; }

        public virtual Movie Movie { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        public virtual Show Show { get; set; }
    }
}
