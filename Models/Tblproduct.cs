using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblproduct")]
public partial class Tblproduct
{
    [Key]
    [Column("product_id", TypeName = "int(11)")]
    public int ProductId { get; set; }

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("price")]
    public float Price { get; set; }

    [Column("quantity", TypeName = "int(5)")]
    public int Quantity { get; set; }

    [Column("quality")]
    [StringLength(100)]
    public string Quality { get; set; } = null!;

    [Column("description")]
    [StringLength(200)]
    public string Description { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [InverseProperty("Product")]
    public virtual ICollection<Tblorder> Tblorders { get; set; } = new List<Tblorder>();

    [InverseProperty("Product")]
    public virtual ICollection<Tblstock> Tblstocks { get; set; } = new List<Tblstock>();
}
