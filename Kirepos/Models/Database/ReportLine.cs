using System;
using System.ComponentModel.DataAnnotations;

namespace Kirepos.Models.Database
{
    public class ReportLine : DatabaseObject
    {
        public Report Report { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Responsible { get; set; }
        public DateTime Deadline { get; set; }
    }
}
