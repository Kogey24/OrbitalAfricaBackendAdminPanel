using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Orbital_Africa_Backend_Recon.Models;

public partial class OrbitalAfricaContext : DbContext
{
    public OrbitalAfricaContext()
    {
    }

    public OrbitalAfricaContext(DbContextOptions<OrbitalAfricaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tbkbooking> Tbkbookings { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    public virtual DbSet<Tbladmin> Tbladmins { get; set; }

    public virtual DbSet<Tblcustomer> Tblcustomers { get; set; }

    public virtual DbSet<TbldispatchManager> TbldispatchManagers { get; set; }

    public virtual DbSet<Tbldriver> Tbldrivers { get; set; }

    public virtual DbSet<Tblfeedback> Tblfeedbacks { get; set; }

    public virtual DbSet<Tblfinace> Tblfinaces { get; set; }

    public virtual DbSet<TblinventoryManager> TblinventoryManagers { get; set; }

    public virtual DbSet<Tblmenu> Tblmenus { get; set; }

    public virtual DbSet<Tblorder> Tblorders { get; set; }

    public virtual DbSet<TblotpManager> TblotpManagers { get; set; }

    public virtual DbSet<Tblpayment> Tblpayments { get; set; }

    public virtual DbSet<Tblproduct> Tblproducts { get; set; }

    public virtual DbSet<TblpwdManager> TblpwdManagers { get; set; }

    public virtual DbSet<TblrefreshToken> TblrefreshTokens { get; set; }

    public virtual DbSet<Tblrole> Tblroles { get; set; }

    public virtual DbSet<TblrolePermission> TblrolePermissions { get; set; }

    public virtual DbSet<Tblservice> Tblservices { get; set; }

    public virtual DbSet<TblserviceManager> TblserviceManagers { get; set; }

    public virtual DbSet<Tblstock> Tblstocks { get; set; }

    public virtual DbSet<Tblsupervisor> Tblsupervisors { get; set; }

    public virtual DbSet<Tblsupplier> Tblsuppliers { get; set; }

    public virtual DbSet<Tblsurveyor> Tblsurveyors { get; set; }

    public virtual DbSet<TbltempUser> TbltempUsers { get; set; }

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("latin1_swedish_ci")
            .HasCharSet("latin1");

        modelBuilder.Entity<Tbkbooking>(entity =>
        {
            entity.HasKey(e => e.BookingId).HasName("PRIMARY");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tbkbookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbkbooking_ibfk_1");

            entity.HasOne(d => d.Service).WithMany(p => p.Tbkbookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbkbooking_ibfk_2");

            entity.HasOne(d => d.ServiceManager).WithMany(p => p.Tbkbookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbkbooking_ibfk_5");

            entity.HasOne(d => d.Supervisor).WithMany(p => p.Tbkbookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbkbooking_ibfk_3");

            entity.HasOne(d => d.Surveyor).WithMany(p => p.Tbkbookings)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tbkbooking_ibfk_4");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tbladmin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tblcustomer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PRIMARY");

            entity.Property(e => e.CustomerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TbldispatchManager>(entity =>
        {
            entity.HasKey(e => e.DispatchManagerId).HasName("PRIMARY");

            entity.Property(e => e.DispatchManagerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tbldriver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PRIMARY");

            entity.Property(e => e.DriverId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tblfeedback>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PRIMARY");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tblfeedbacks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblfeedback_ibfk_1");
        });

        modelBuilder.Entity<Tblfinace>(entity =>
        {
            entity.HasKey(e => e.FinanceId).HasName("PRIMARY");

            entity.Property(e => e.FinanceId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TblinventoryManager>(entity =>
        {
            entity.HasKey(e => e.InventoryManagerId).HasName("PRIMARY");

            entity.Property(e => e.InventoryManagerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tblmenu>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblorder>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PRIMARY");

            entity.Property(e => e.OrderId).ValueGeneratedNever();

            entity.HasOne(d => d.Customer).WithMany(p => p.Tblorders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblorder_ibfk_2");

            entity.HasOne(d => d.DispatchManager).WithMany(p => p.Tblorders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblorder_ibfk_3");

            entity.HasOne(d => d.Driver).WithMany(p => p.Tblorders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblorder_ibfk_4");

            entity.HasOne(d => d.InventoryManager).WithMany(p => p.Tblorders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblorder_ibfk_1");

            entity.HasOne(d => d.Product).WithMany(p => p.Tblorders)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblorder_ibfk_5");
        });

        modelBuilder.Entity<TblotpManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblpayment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PRIMARY");

            entity.Property(e => e.PaymentId).ValueGeneratedNever();

            entity.HasOne(d => d.Booking).WithMany(p => p.Tblpayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblpayment_ibfk_3");

            entity.HasOne(d => d.Customer).WithMany(p => p.Tblpayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblpayment_ibfk_2");

            entity.HasOne(d => d.Finance).WithMany(p => p.Tblpayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblpayment_ibfk_4");

            entity.HasOne(d => d.Order).WithMany(p => p.Tblpayments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblpayment_ibfk_1");
        });

        modelBuilder.Entity<Tblproduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");
        });

        modelBuilder.Entity<TblpwdManager>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<TblrefreshToken>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblrole>(entity =>
        {
            entity.HasKey(e => e.Code).HasName("PRIMARY");
        });

        modelBuilder.Entity<TblrolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        modelBuilder.Entity<Tblservice>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PRIMARY");
        });

        modelBuilder.Entity<TblserviceManager>(entity =>
        {
            entity.HasKey(e => e.ServiceManagerId).HasName("PRIMARY");

            entity.Property(e => e.ServiceManagerId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tblstock>(entity =>
        {
            entity.HasKey(e => e.StockId).HasName("PRIMARY");

            entity.Property(e => e.StockId).ValueGeneratedNever();

            entity.HasOne(d => d.InventoryManager).WithMany(p => p.Tblstocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblstock_ibfk_3");

            entity.HasOne(d => d.Product).WithMany(p => p.Tblstocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblstock_ibfk_1");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Tblstocks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tblstock_ibfk_2");
        });

        modelBuilder.Entity<Tblsupervisor>(entity =>
        {
            entity.HasKey(e => e.SupervisorId).HasName("PRIMARY");

            entity.Property(e => e.SupervisorId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tblsupplier>(entity =>
        {
            entity.HasKey(e => e.SupplierId).HasName("PRIMARY");

            entity.Property(e => e.SupplierId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Tblsurveyor>(entity =>
        {
            entity.HasKey(e => e.SurveyorId).HasName("PRIMARY");

            entity.Property(e => e.SurveyorId).ValueGeneratedNever();
        });

        modelBuilder.Entity<TbltempUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
