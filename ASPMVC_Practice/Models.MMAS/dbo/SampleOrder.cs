using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using ASPMVC_Practice.Models.MMAS.dboSchema;


namespace ASPMVC_Practice.Models.MMAS.dboSchema
{
    [Table("SampleOrder")]
    public partial class SampleOrder
    {
        [Key]
        public int OrderID { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }
        [StringLength(100)]
        public string? CustomerID { get; set; }
        [StringLength(100)]
        public string? CustomerName { get; set; }
        [StringLength(100)]
        public string? ShipCountry { get; set; }
        [StringLength(100)]
        public string? ShipCity { get; set; }
    }
}

