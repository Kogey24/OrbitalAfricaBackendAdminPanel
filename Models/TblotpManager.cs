using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblotp_manager")]
public partial class TblotpManager
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("otptext")]
    [StringLength(20)]
    public string Otptext { get; set; } = null!;

    [Column("otpttype")]
    [StringLength(20)]
    public string Otpttype { get; set; } = null!;

    [Column("expiration", TypeName = "datetime")]
    public DateTime Expiration { get; set; }

    [Column("create_date", TypeName = "datetime")]
    public DateTime CreateDate { get; set; }
}
