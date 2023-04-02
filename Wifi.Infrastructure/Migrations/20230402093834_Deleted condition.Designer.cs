﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wifi.Infrastructure;

#nullable disable

namespace Wifi.Infrastructure.Migrations
{
    [DbContext(typeof(WifiContext))]
    [Migration("20230402093834_Deleted condition")]
    partial class Deletedcondition
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Wifi.Domain.Entity.Cleaning", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("RoomId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeOfCleaning")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("RoomId");

                    b.ToTable("Cleaning");
                });

            modelBuilder.Entity("Wifi.Domain.Entity.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("Employee");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "peter@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 2,
                            Email = "martina@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 3,
                            Email = "orhan@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 4,
                            Email = "benjamin@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 5,
                            Email = "milos@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 6,
                            Email = "martind@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 7,
                            Email = "jan@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 8,
                            Email = "romana@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 9,
                            Email = "frederik@mighty-putztrupp.at",
                            Password = "test1234"
                        },
                        new
                        {
                            Id = 10,
                            Email = "romed@mighty-putztrupp.at",
                            Password = "test1234"
                        });
                });

            modelBuilder.Entity("Wifi.Domain.Entity.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nfc_Id")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("Wifi.Domain.Entity.Cleaning", b =>
                {
                    b.HasOne("Wifi.Domain.Entity.Employee", "Employee")
                        .WithMany("Cleanings")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wifi.Domain.Entity.Room", "Room")
                        .WithMany("Cleanings")
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Wifi.Domain.Entity.Employee", b =>
                {
                    b.Navigation("Cleanings");
                });

            modelBuilder.Entity("Wifi.Domain.Entity.Room", b =>
                {
                    b.Navigation("Cleanings");
                });
#pragma warning restore 612, 618
        }
    }
}
