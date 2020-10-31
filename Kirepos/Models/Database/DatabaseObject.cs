using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Kirepos.Models.Database
{
    public abstract class DatabaseObject
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(1024)]
        public string CreatedBy { get; set; }
        
        public DateTimeOffset CreatedOn { get; set; }
        
        [MaxLength(1024)]
        public string UpdatedBy { get; set; }
        
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}