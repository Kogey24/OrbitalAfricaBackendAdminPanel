using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tbltemp_user")]
public partial class TbltempUser
{
    [Key]
    [Column("id", TypeName = "int(11)")]
    public int Id { get; set; }

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("Last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("gender")]
    [StringLength(50)]
    public string Gender { get; set; } = null!;

    [Column("role")]
    [StringLength(50)]
    public string Role { get; set; } = null!;

    [Column("status")]
    [StringLength(50)]
    public string Status { get; set; } = null!;

    [Column("address")]
    [StringLength(100)]
    public string Address { get; set; } = null!;
}
