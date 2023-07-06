namespace DACS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("task")]
    public partial class task
    {
        public int? IdPos { get; set; }

        public int? idNv { get; set; }

        public string TaskDetails { get; set; }
        public bool process { get; set; }

        [Key]
        [StringLength(256)]
        public string EmployeeName { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Position Position { get; set; }
        [Column(TypeName = "date")]
        public DateTime? dateofduty { get; set; }
    }
}
