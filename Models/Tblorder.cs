using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblorder")]
[Index("CustomerId", Name = "customer_id")]
[Index("DispatchManagerId", Name = "dispatch_manager_id")]
[Index("DriverId", Name = "driver_id")]
[Index("InventoryManagerId", Name = "inventory_manager_id")]
[Index("ProductId", Name = "product_id")]
public partial class Tblorder
{
    [Key]
    [Column("order_id", TypeName = "int(10)")]
    public int OrderId { get; set; }

    [Column("ordered_date", TypeName = "datetime")]
    public DateTime OrderedDate { get; set; }

    [Column("product_id", TypeName = "int(10)")]
    public int ProductId { get; set; }

    [Column("inventory_manager_id", TypeName = "int(10)")]
    public int InventoryManagerId { get; set; }

    [Column("customer_id", TypeName = "int(10)")]
    public int CustomerId { get; set; }

    [Column("dispatch_manager_id", TypeName = "int(10)")]
    public int DispatchManagerId { get; set; }

    [Column("driver_id", TypeName = "int(10)")]
    public int DriverId { get; set; }

    [Column("status")]
    [StringLength(20)]
    public string? Status { get; set; }

    [ForeignKey("CustomerId")]
    [InverseProperty("Tblorders")]
    public virtual Tblcustomer Customer { get; set; } = null!;

    [ForeignKey("DispatchManagerId")]
    [InverseProperty("Tblorders")]
    public virtual TbldispatchManager DispatchManager { get; set; } = null!;

    [ForeignKey("DriverId")]
    [InverseProperty("Tblorders")]
    public virtual Tbldriver Driver { get; set; } = null!;

    [ForeignKey("InventoryManagerId")]
    [InverseProperty("Tblorders")]
    public virtual TblinventoryManager InventoryManager { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Tblorders")]
    public virtual Tblproduct Product { get; set; } = null!;

    [InverseProperty("Order")]
    public virtual ICollection<Tblpayment> Tblpayments { get; set; } = new List<Tblpayment>();
}
