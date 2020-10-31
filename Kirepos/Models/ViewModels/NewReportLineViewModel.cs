using System;

namespace Kirepos.Models.ViewModels
{
    public class NewReportLineViewModel
    {
        public Guid ReportId { get; set; }
        public DateTime Deadline { get; set; }
        public string Responsible { get; set; }
        public string Description { get; set; }
        public string Location { get; set; }
    }
}
