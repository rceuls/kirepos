using System;

namespace Kirepos.Models.Database
{
    public class Report : DatabaseObject
    {
        public string Description { get; set; }
        public DateTime ReportedOn { get; set; }
    }
}
