using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kirepos.Models.Database
{
    public class Report : DatabaseObject
    {
        [Required]
        public string Description { get; set; }
        public DateTime ReportedOn { get; set; }
        public List<ReportLine> Lines { get; set; }
    }
}
