using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookMyShow.Models
{
    public class ReportInfo
    {
        [Key]
        public int ReportId { get; set; }
        public string ReportName { get; set; }
        public string ReportDescription { get; set; }
        public string ReportURL { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string ReportSummary { get; set; }
    }
}