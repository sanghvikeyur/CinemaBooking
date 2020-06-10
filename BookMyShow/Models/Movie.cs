namespace BookMyShow.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    [Table("Movie")]
    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            Bookings = new HashSet<Booking>();
            Orders = new HashSet<Order>();
            Shows = new HashSet<Show>();
            Tickets = new HashSet<Ticket>();
        }

        [Key]
        public int MoviedId { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [StringLength(20)]
        public string Type { get; set; }

        [Required]
        [StringLength(20)]
        public string Genre { get; set; }

        [Required]
        [StringLength(10)]
        public string Status { get; set; }

        public string Icon { get; set; }

        [NotMapped]
        public HttpPostedFileBase MovieIcon { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
	    [StringLength(5)]
	    public string Rating { get; set; }

        public int? RateCount
	    {
            get { return ratings.Count; }
	    }
	    public int? RateTotal
	    {
	        get
	        {
	            return (ratings.Sum(m => m.Rate));
	        }
	    }
	    public virtual ICollection<StarRatings> ratings { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking> Bookings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Show> Shows { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
