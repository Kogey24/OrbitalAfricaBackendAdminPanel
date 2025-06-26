using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblstock")]
[Index("InventoryManagerId", Name = "inventory_manager_id")]
[Index("ProductId", Name = "product_id")]
[Index("SupplierId", Name = "supplier_id")]
public partial class Tblstock
{
    [Key]
    [Column("stock_id", TypeName = "int(10)")]
    public int StockId { get; set; }

    [Column("product_id", TypeName = "int(10)")]
    public int ProductId { get; set; }

    [Column("supplier_id", TypeName = "int(10)")]
    public int SupplierId { get; set; }

    [Column("inventory_manager_id", TypeName = "int(10)")]
    public int InventoryManagerId { get; set; }

    [Column("descrption")]
    [StringLength(500)]
    public string Descrption { get; set; } = null!;

    [Column("quantity", TypeName = "int(10)")]
    public int Quantity { get; set; }

    [Column("price")]
    public float Price { get; set; }

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;

    [ForeignKey("InventoryManagerId")]
    [InverseProperty("Tblstocks")]
    public virtual TblinventoryManager InventoryManager { get; set; } = null!;

    [ForeignKey("ProductId")]
    [InverseProperty("Tblstocks")]
    public virtual Tblproduct Product { get; set; } = null!;

    [ForeignKey("SupplierId")]
    [InverseProperty("Tblstocks")]
    public virtual Tblsupplier Supplier { get; set; } = null!;
}
