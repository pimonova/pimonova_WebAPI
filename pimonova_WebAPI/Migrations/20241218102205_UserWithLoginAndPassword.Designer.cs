﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using pimonova_WebAPI.Data;

#nullable disable

namespace pimonova_WebAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241218102205_UserWithLoginAndPassword")]
    partial class UserWithLoginAndPassword
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("pimonova_WebAPI.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("CurrAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Director")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("INN")
                        .HasColumnType("bigint");

                    b.Property<int>("KPP")
                        .HasColumnType("integer");

                    b.Property<string>("LineOfWork")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long>("OGRN")
                        .HasColumnType("bigint");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RegAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.ObjectOfNEI", b =>
                {
                    b.Property<int>("ObjectOfNEIID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("ObjectOfNEIID"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("CompanyID")
                        .HasColumnType("integer");

                    b.Property<string>("LocationAddress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("ObjectOfNEIID");

                    b.HasIndex("CompanyID");

                    b.ToTable("ObjectsOfNEI");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.Sector", b =>
                {
                    b.Property<int>("SectorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("SectorID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberInCompany")
                        .HasColumnType("integer");

                    b.Property<int>("WorkshopID")
                        .HasColumnType("integer");

                    b.HasKey("SectorID");

                    b.HasIndex("WorkshopID");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("UserID"));

                    b.Property<int>("CompanyID")
                        .HasColumnType("integer");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("UserID");

                    b.HasIndex("CompanyID");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.Workshop", b =>
                {
                    b.Property<int>("WorkshopID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("WorkshopID"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("NumberInCompany")
                        .HasColumnType("integer");

                    b.Property<int>("ObjectOfNEIID")
                        .HasColumnType("integer");

                    b.HasKey("WorkshopID");

                    b.HasIndex("ObjectOfNEIID");

                    b.ToTable("Workshops");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.ObjectOfNEI", b =>
                {
                    b.HasOne("pimonova_WebAPI.Models.Company", "Company")
                        .WithMany("ObjectOfNEI")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.Sector", b =>
                {
                    b.HasOne("pimonova_WebAPI.Models.Workshop", "Workshop")
                        .WithMany("Sectors")
                        .HasForeignKey("WorkshopID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Workshop");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.User", b =>
                {
                    b.HasOne("pimonova_WebAPI.Models.Company", "Company")
                        .WithMany("Users")
                        .HasForeignKey("CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.Workshop", b =>
                {
                    b.HasOne("pimonova_WebAPI.Models.ObjectOfNEI", "ObjectOfNEI")
                        .WithMany("Workshops")
                        .HasForeignKey("ObjectOfNEIID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ObjectOfNEI");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.Company", b =>
                {
                    b.Navigation("ObjectOfNEI");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.ObjectOfNEI", b =>
                {
                    b.Navigation("Workshops");
                });

            modelBuilder.Entity("pimonova_WebAPI.Models.Workshop", b =>
                {
                    b.Navigation("Sectors");
                });
#pragma warning restore 612, 618
        }
    }
}
