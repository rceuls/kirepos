using System;
using System.ComponentModel.DataAnnotations;

namespace Kirepos.Models.ViewModels
{
    public class NewReportViewModel
    {
        [MinLength(2)]
        [MaxLength(1024)]
        [Required] 
        public string Description { get; set; }
        
        [DataType(DataType.Date)]	
        public DateTime ReportDate { get; set; }
    }
}
