using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblpayment")]
[Index("BookingId", Name = "booking_id")]
[Index("CustomerId", Name = "customer_id")]
[Index("FinanceId", Name = "finance_id")]
[Index("OrderId", Name = "order_id")]
public partial class Tblpayment
{
    [Key]
    [Column("payment_id", TypeName = "int(10)")]
    public int PaymentId { get; set; }

    [Column("amount_paid")]
    public float AmountPaid { get; set; }

    [Column("date_paid", TypeName = "datetime")]
    public DateTime DatePaid { get; set; }

    [Column("payment_method")]
    [StringLength(50)]
    public string PaymentMethod { get; set; } = null!;

    [Column("transaction_code")]
    [StringLength(50)]
    public string TransactionCode { get; set; } = null!;

    [Column("order_id", TypeName = "int(10)")]
    public int OrderId { get; set; }

    [Column("customer_id", TypeName = "int(10)")]
    public int CustomerId { get; set; }

    [Column("booking_id", TypeName = "int(10)")]
    public int BookingId { get; set; }

    [Column("finance_id", TypeName = "int(10)")]
    public int FinanceId { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [ForeignKey("BookingId")]
    [InverseProperty("Tblpayments")]
    public virtual Tbkbooking Booking { get; set; } = null!;

    [ForeignKey("CustomerId")]
    [InverseProperty("Tblpayments")]
    public virtual Tblcustomer Customer { get; set; } = null!;

    [ForeignKey("FinanceId")]
    [InverseProperty("Tblpayments")]
    public virtual Tblfinace Finance { get; set; } = null!;

    [ForeignKey("OrderId")]
    [InverseProperty("Tblpayments")]
    public virtual Tblorder Order { get; set; } = null!;
}
