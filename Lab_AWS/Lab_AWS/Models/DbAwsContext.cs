using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Lab_AWS.Models;

public partial class DbAwsContext : DbContext
{
    public DbAwsContext()
    {
    }

    public DbAwsContext(DbContextOptions<DbAwsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Invoke> DbInvokes { get; set; }

    public virtual DbSet<Company> TbCompanies { get; set; }

    public virtual DbSet<Product> TbProducts { get; set; }

    public virtual DbSet<Staff> TbStaffs { get; set; }

    public virtual DbSet<Truck> TbTrucks { get; set; }

    public virtual DbSet<Truckdetail> TbTruckdetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=group-02.cl1k4lehkuin.ap-southeast-2.rds.amazonaws.com;Initial Catalog=db_AWS;Persist Security Info=True;User ID=admin;Password=group022023;Trusted_Connection=True;encrypt=false;Integrated Security=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Invoke>(entity =>
        {
            entity.HasKey(e => e.IdInvoke);

            entity.ToTable("db_invoke");

            entity.Property(e => e.IdInvoke)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_Invoke");
            entity.Property(e => e.Datetime).HasColumnType("date");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_product");
            entity.Property(e => e.IdStaff)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_staff");
        });

        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.IdCompany);

            entity.ToTable("tb_company");

            entity.Property(e => e.IdCompany)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_company");
            entity.Property(e => e.Contact).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct);

            entity.ToTable("tb_product");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_product");
            entity.Property(e => e.IdCompany)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_company");
            entity.Property(e => e.MaxQuantity).HasColumnName("Max_quantity");
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.IdStaff);

            entity.ToTable("tb_staff");

            entity.Property(e => e.IdStaff)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_staff");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.Role).HasMaxLength(100);
        });

        modelBuilder.Entity<Truck>(entity =>
        {
            entity.HasKey(e => e.IdTruck);

            entity.ToTable("tb_truck");

            entity.Property(e => e.IdTruck)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_truck");
            entity.Property(e => e.IdStaff)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_staff");
            entity.Property(e => e.LicensePlates)
                .HasMaxLength(50)
                .HasColumnName("License_plates");
        });

        modelBuilder.Entity<Truckdetail>(entity =>
        {
            entity.HasKey(e => new { e.IdTruck, e.IdProduct });

            entity.ToTable("tb_truckdetail");

            entity.Property(e => e.IdTruck)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_truck");
            entity.Property(e => e.IdProduct)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ID_product");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
