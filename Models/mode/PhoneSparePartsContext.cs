using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication6.mode;

public partial class PhoneSparePartsContext : DbContext
{
    public PhoneSparePartsContext()
    {
    }

    public PhoneSparePartsContext(DbContextOptions<PhoneSparePartsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

   

    public virtual DbSet<Catagory> Catagories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }


    public virtual DbSet<SparePart> SpareParts { get; set; }

    public virtual DbSet<Users> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-LU175Q4\\SQLEXPRESS01;Initial Catalog=Phone_Spare_Parts;Integrated Security=True; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BId).HasName("PK__Brands__4B26EFE62DB619A0");

            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.BName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("B_Name");
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

    
        modelBuilder.Entity<Catagory>(entity =>
        {
            entity.HasKey(e => e.CId).HasName("PK__Catagori__A9FDEC1242B3CA69");

            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.BId).HasColumnName("B_ID");
            entity.Property(e => e.CName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("C_Name");

            entity.HasOne(d => d.BIdNavigation).WithMany(p => p.Catagories)
                .HasForeignKey(d => d.BId)
                .HasConstraintName("FK__Catagories__B_ID__4BAC3F29");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OId).HasName("PK__Orders__5AAB0C184C810E8A");

            entity.Property(e => e.OId).HasColumnName("O_ID");
            entity.Property(e => e.ODate)
                .HasColumnType("date")
                .HasColumnName("O_Date");
            entity.Property(e => e.SId).HasColumnName("S_ID");
            entity.Property(e => e.UId).HasColumnName("U_ID");

            entity.HasOne(d => d.SIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.SId)
                .HasConstraintName("FK__Orders__S_ID__76969D2E");

            entity.HasOne(d => d.UIdNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UId)
                .HasConstraintName("FK__Orders__U_ID__75A278F5");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PId).HasName("PK__Payments__A3420A77BE9739B9");

            entity.Property(e => e.PId).HasColumnName("P_ID");
            entity.Property(e => e.OId).HasColumnName("O_ID");
            entity.Property(e => e.PDate)
                .HasColumnType("date")
                .HasColumnName("P_Date");
            entity.Property(e => e.PMethod)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("P_Method");
            entity.Property(e => e.TotalPrice).HasColumnName("Total_Price");

            entity.HasOne(d => d.OIdNavigation).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OId)
                .HasConstraintName("FK__Payments__O_ID__797309D9");
        });


        modelBuilder.Entity<SparePart>(entity =>
        {
            entity.HasKey(e => e.SId).HasName("PK__SPARE_PA__A3DFF16DAF32E7DA");

            entity.ToTable("SPARE_PARTS");

            entity.Property(e => e.SId).HasColumnName("S_ID");
            entity.Property(e => e.CId).HasColumnName("C_ID");
            entity.Property(e => e.Describtion)
                .HasColumnType("text")
                .HasColumnName("describtion");
            entity.Property(e => e.SName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("S_Name");

            entity.HasOne(d => d.CIdNavigation).WithMany(p => p.SpareParts)
                .HasForeignKey(d => d.CId)
                .HasConstraintName("FK__SPARE_PART__C_ID__4E88ABD4");
        });

        modelBuilder.Entity<Users>(entity =>
        {
            entity.HasKey(e => e.UId).HasName("PK__Users__5A2040DB6E9AAF88");

            entity.Property(e => e.UId).HasColumnName("U_ID");
            entity.Property(e => e.Addres).HasColumnType("text");
            entity.Property(e => e.EMail)
                .HasColumnName("E_mail");
            entity.Property(e => e.FName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("F_Name");
            entity.Property(e => e.LName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("L_Name");
            entity.Property(e => e.PankCode)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("Pank_Code");
            entity.Property(e => e.Pass)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(11)
                .IsUnicode(false);
            entity.Property(e => e.Photo).HasColumnType("image");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
