using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tbladmin")]
public partial class Tbladmin
{
    [Key]
    [Column("id", TypeName = "int(10)")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;
}
