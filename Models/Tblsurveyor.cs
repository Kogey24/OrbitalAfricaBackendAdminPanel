using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblsurveyor")]
public partial class Tblsurveyor
{
    [Key]
    [Column("surveyor_id", TypeName = "int(10)")]
    public int SurveyorId { get; set; }

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("gender")]
    [StringLength(10)]
    public string Gender { get; set; } = null!;

    [Column("email")]
    [StringLength(50)]
    public string Email { get; set; } = null!;

    [Column("phone")]
    [StringLength(20)]
    public string Phone { get; set; } = null!;

    [Column("address")]
    [StringLength(100)]
    public string Address { get; set; } = null!;

    [Column("username")]
    [StringLength(50)]
    public string Username { get; set; } = null!;

    [Column("password")]
    [StringLength(50)]
    public string Password { get; set; } = null!;

    [Column("status")]
    [StringLength(20)]
    public string Status { get; set; } = null!;

    [InverseProperty("Surveyor")]
    public virtual ICollection<Tbkbooking> Tbkbookings { get; set; } = new List<Tbkbooking>();
}
