using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookMyShow.Models
{
    public class StarRatings
    {
        [Key] 
	    public int RateId { get; set; }
	    public int Rate { get; set; }    
        public int MovieId { get; set; }

	    [ForeignKey("MovieId")]
	    public virtual Movie movie { get; set; }
    }
}