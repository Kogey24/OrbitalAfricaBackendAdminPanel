using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tbkbooking")]
[Index("CustomerId", Name = "customer_id")]
[Index("ServiceId", Name = "service_id")]
[Index("ServiceManagerId", Name = "service_manager_id")]
[Index("SupervisorId", Name = "supervisor_id")]
[Index("SurveyorId", Name = "surveyor_id")]
public partial class Tbkbooking
{
    [Key]
    [Column("booking_id", TypeName = "int(11)")]
    public int BookingId { get; set; }

    [Column("booking_date", TypeName = "datetime")]
    public DateTime BookingDate { get; set; }

    [Column("customer_id", TypeName = "int(10)")]
    public int CustomerId { get; set; }

    [Column("service_id", TypeName = "int(11)")]
    public int ServiceId { get; set; }

    [Column("supervisor_id", TypeName = "int(10)")]
    public int SupervisorId { get; set; }

    [Column("surveyor_id", TypeName = "int(10)")]
    public int SurveyorId { get; set; }

    [Column("service_manager_id", TypeName = "int(10)")]
    public int ServiceManagerId { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string? Status { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Tbkbookings")]
    public virtual Tblcustomer Customer { get; set; } = null!;

    [ForeignKey("ServiceId")]
    [InverseProperty("Tbkbookings")]
    public virtual Tblservice Service { get; set; } = null!;

    [ForeignKey("ServiceManagerId")]
    [InverseProperty("Tbkbookings")]
    public virtual TblserviceManager ServiceManager { get; set; } = null!;

    [ForeignKey("SupervisorId")]
    [InverseProperty("Tbkbookings")]
    public virtual Tblsupervisor Supervisor { get; set; } = null!;

    [ForeignKey("SurveyorId")]
    [InverseProperty("Tbkbookings")]
    public virtual Tblsurveyor Surveyor { get; set; } = null!;

    [InverseProperty("Booking")]
    public virtual ICollection<Tblpayment> Tblpayments { get; set; } = new List<Tblpayment>();
}
