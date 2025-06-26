using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblrefresh_token")]
public partial class TblrefreshToken
{
    [Key]
    [Column("userid")]
    [StringLength(50)]
    public string Userid { get; set; } = null!;

    [Column("tokenid")]
    [StringLength(50)]
    public string Tokenid { get; set; } = null!;

    [Column("refreshtoken")]
    [StringLength(255)]
    public string Refreshtoken { get; set; } = null!;
}
