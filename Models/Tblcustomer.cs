﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Orbital_Africa_Backend_Recon.Models;

[Table("tblcustomer")]
public partial class Tblcustomer
{
    [Key]
    [Column("customer_id", TypeName = "int(10)")]
    public int CustomerId { get; set; }

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

    [InverseProperty("Customer")]
    public virtual ICollection<Tbkbooking> Tbkbookings { get; set; } = new List<Tbkbooking>();

    [InverseProperty("Customer")]
    public virtual ICollection<Tblfeedback> Tblfeedbacks { get; set; } = new List<Tblfeedback>();

    [InverseProperty("Customer")]
    public virtual ICollection<Tblorder> Tblorders { get; set; } = new List<Tblorder>();

    [InverseProperty("Customer")]
    public virtual ICollection<Tblpayment> Tblpayments { get; set; } = new List<Tblpayment>();
}
