using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblfeedback")]
[Index("CustomerId", Name = "customer_id")]
public partial class Tblfeedback
{
    [Key]
    [Column("feedback_id", TypeName = "int(10)")]
    public int FeedbackId { get; set; }

    [Column("customer_id", TypeName = "int(10)")]
    public int CustomerId { get; set; }

    [Column("message")]
    [StringLength(500)]
    public string Message { get; set; } = null!;

    [Column("reply")]
    [StringLength(500)]
    public string Reply { get; set; } = null!;

    [Column("date", TypeName = "datetime")]
    public DateTime Date { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Tblfeedbacks")]
    public virtual Tblcustomer Customer { get; set; } = null!;
}
