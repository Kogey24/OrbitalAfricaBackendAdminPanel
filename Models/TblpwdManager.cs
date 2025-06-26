using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblpwd_manager")]
public partial class TblpwdManager
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("modifydate", TypeName = "datetime")]
    public DateTime Modifydate { get; set; }
}
