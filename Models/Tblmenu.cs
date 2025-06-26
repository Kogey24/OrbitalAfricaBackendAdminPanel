using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblmenu")]
public partial class Tblmenu
{
    [Key]
    [Column("code")]
    [StringLength(50)]
    public string Code { get; set; } = null!;

    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; } = null!;

    [Column("isactive")]
    public bool Isactive { get; set; }
}
