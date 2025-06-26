using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblservice")]
public partial class Tblservice
{
    [Key]
    [Column("service_id", TypeName = "int(11)")]
    public int ServiceId { get; set; }

    [Column("service_name")]
    [StringLength(50)]
    public string ServiceName { get; set; } = null!;

    [Column("charges")]
    public float Charges { get; set; }

    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [InverseProperty("Service")]
    public virtual ICollection<Tbkbooking> Tbkbookings { get; set; } = new List<Tbkbooking>();
}
