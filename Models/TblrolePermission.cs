using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblrole_permission")]
public partial class TblrolePermission
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("userrole")]
    [StringLength(50)]
    public string Userrole { get; set; } = null!;

    [Column("menucode")]
    [StringLength(50)]
    public string Menucode { get; set; } = null!;

    [Column("haveview")]
    public bool Haveview { get; set; }

    [Column("haveadd")]
    public bool Haveadd { get; set; }

    [Column("haveedit")]
    public bool Haveedit { get; set; }

    [Column("havedelete")]
    public bool Havedelete { get; set; }
}
