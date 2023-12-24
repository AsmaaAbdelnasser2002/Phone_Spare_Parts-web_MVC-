﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication6.mode;

#nullable disable

namespace WebApplication6.Migrations
{
    [DbContext(typeof(PhoneSparePartsContext))]
    [Migration("20231206213447_Initial migration")]
    partial class Initialmigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApplication6.mode.Brand", b =>
                {
                    b.Property<int>("BId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("B_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BId"));

                    b.Property<string>("BName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("B_Name");

                    b.Property<string>("Country")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.HasKey("BId")
                        .HasName("PK__Brands__4B26EFE62DB619A0");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("WebApplication6.mode.Cart", b =>
                {
                    b.Property<int>("CaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Ca_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CaId"));

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SId")
                        .HasColumnType("int")
                        .HasColumnName("S_ID");

                    b.Property<int?>("UId")
                        .HasColumnType("int")
                        .HasColumnName("U_ID");

                    b.HasKey("CaId")
                        .HasName("PK__Cart__646DFDC6C2496E76");

                    b.HasIndex("SId");

                    b.HasIndex("UId");

                    b.ToTable("Cart", (string)null);
                });

            modelBuilder.Entity("WebApplication6.mode.Catagory", b =>
                {
                    b.Property<int>("CId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("C_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CId"));

                    b.Property<int?>("BId")
                        .HasColumnType("int")
                        .HasColumnName("B_ID");

                    b.Property<string>("CName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("C_Name");

                    b.HasKey("CId")
                        .HasName("PK__Catagori__A9FDEC1242B3CA69");

                    b.HasIndex("BId");

                    b.ToTable("Catagories");
                });

            modelBuilder.Entity("WebApplication6.mode.Order", b =>
                {
                    b.Property<int>("OId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("O_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OId"));

                    b.Property<DateTime?>("ODate")
                        .HasColumnType("date")
                        .HasColumnName("O_Date");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.Property<int?>("SId")
                        .HasColumnType("int")
                        .HasColumnName("S_ID");

                    b.Property<int?>("UId")
                        .HasColumnType("int")
                        .HasColumnName("U_ID");

                    b.HasKey("OId")
                        .HasName("PK__Orders__5AAB0C184C810E8A");

                    b.HasIndex("SId");

                    b.HasIndex("UId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("WebApplication6.mode.Payment", b =>
                {
                    b.Property<int>("PId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("P_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PId"));

                    b.Property<int?>("OId")
                        .HasColumnType("int")
                        .HasColumnName("O_ID");

                    b.Property<DateTime?>("PDate")
                        .HasColumnType("date")
                        .HasColumnName("P_Date");

                    b.Property<string>("PMethod")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("P_Method");

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float")
                        .HasColumnName("Total_Price");

                    b.HasKey("PId")
                        .HasName("PK__Payments__A3420A77BE9739B9");

                    b.HasIndex("OId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("WebApplication6.mode.Reviewe", b =>
                {
                    b.Property<int>("RId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("R_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RId"));

                    b.Property<int?>("Rate")
                        .HasColumnType("int");

                    b.Property<int?>("SId")
                        .HasColumnType("int")
                        .HasColumnName("S_ID");

                    b.HasKey("RId")
                        .HasName("PK__REVIEWES__DE152E891DC18DF7");

                    b.HasIndex("SId");

                    b.ToTable("REVIEWES", (string)null);
                });

            modelBuilder.Entity("WebApplication6.mode.SparePart", b =>
                {
                    b.Property<int>("SId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("S_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SId"));

                    b.Property<int?>("CId")
                        .HasColumnType("int")
                        .HasColumnName("C_ID");

                    b.Property<string>("Describtion")
                        .HasColumnType("text")
                        .HasColumnName("describtion");

                    b.Property<string>("SName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("S_Name");

                    b.HasKey("SId")
                        .HasName("PK__SPARE_PA__A3DFF16DAF32E7DA");

                    b.HasIndex("CId");

                    b.ToTable("SPARE_PARTS", (string)null);
                });

            modelBuilder.Entity("WebApplication6.mode.Users", b =>
                {
                    b.Property<int>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("U_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UId"));

                    b.Property<string>("Addres")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("EMail")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("E_mail");

                    b.Property<string>("FName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("F_Name");

                    b.Property<string>("LName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("L_Name");

                    b.Property<string>("PankCode")
                        .HasMaxLength(16)
                        .IsUnicode(false)
                        .HasColumnType("varchar(16)")
                        .HasColumnName("Pank_Code");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("image");

                    b.HasKey("UId")
                        .HasName("PK__Users__5A2040DB6E9AAF88");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("WebApplication6.mode.Cart", b =>
                {
                    b.HasOne("WebApplication6.mode.SparePart", "SIdNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("SId")
                        .HasConstraintName("FK__Cart__S_ID__72C60C4A");

                    b.HasOne("WebApplication6.mode.Users", "UIdNavigation")
                        .WithMany("Carts")
                        .HasForeignKey("UId")
                        .HasConstraintName("FK__Cart__U_ID__71D1E811");

                    b.Navigation("SIdNavigation");

                    b.Navigation("UIdNavigation");
                });

            modelBuilder.Entity("WebApplication6.mode.Catagory", b =>
                {
                    b.HasOne("WebApplication6.mode.Brand", "BIdNavigation")
                        .WithMany("Catagories")
                        .HasForeignKey("BId")
                        .HasConstraintName("FK__Catagories__B_ID__4BAC3F29");

                    b.Navigation("BIdNavigation");
                });

            modelBuilder.Entity("WebApplication6.mode.Order", b =>
                {
                    b.HasOne("WebApplication6.mode.SparePart", "SIdNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("SId")
                        .HasConstraintName("FK__Orders__S_ID__76969D2E");

                    b.HasOne("WebApplication6.mode.Users", "UIdNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("UId")
                        .HasConstraintName("FK__Orders__U_ID__75A278F5");

                    b.Navigation("SIdNavigation");

                    b.Navigation("UIdNavigation");
                });

            modelBuilder.Entity("WebApplication6.mode.Payment", b =>
                {
                    b.HasOne("WebApplication6.mode.Order", "OIdNavigation")
                        .WithMany("Payments")
                        .HasForeignKey("OId")
                        .HasConstraintName("FK__Payments__O_ID__797309D9");

                    b.Navigation("OIdNavigation");
                });

            modelBuilder.Entity("WebApplication6.mode.Reviewe", b =>
                {
                    b.HasOne("WebApplication6.mode.SparePart", "SIdNavigation")
                        .WithMany("Reviewes")
                        .HasForeignKey("SId")
                        .HasConstraintName("FK__REVIEWES__S_ID__5165187F");

                    b.Navigation("SIdNavigation");
                });

            modelBuilder.Entity("WebApplication6.mode.SparePart", b =>
                {
                    b.HasOne("WebApplication6.mode.Catagory", "CIdNavigation")
                        .WithMany("SpareParts")
                        .HasForeignKey("CId")
                        .HasConstraintName("FK__SPARE_PART__C_ID__4E88ABD4");

                    b.Navigation("CIdNavigation");
                });

            modelBuilder.Entity("WebApplication6.mode.Brand", b =>
                {
                    b.Navigation("Catagories");
                });

            modelBuilder.Entity("WebApplication6.mode.Catagory", b =>
                {
                    b.Navigation("SpareParts");
                });

            modelBuilder.Entity("WebApplication6.mode.Order", b =>
                {
                    b.Navigation("Payments");
                });

            modelBuilder.Entity("WebApplication6.mode.SparePart", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Reviewes");
                });

            modelBuilder.Entity("WebApplication6.mode.Users", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
