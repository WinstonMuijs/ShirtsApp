﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shirts.Data;

#nullable disable

namespace Shirts.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230910112857_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Shirts.Models.Shirt", b =>
                {
                    b.Property<int>("ShirtId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ShirtId"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int?>("Size")
                        .HasColumnType("int");

                    b.HasKey("ShirtId");

                    b.ToTable("Shirts");

                    b.HasData(
                        new
                        {
                            ShirtId = 1,
                            Brand = "Levy",
                            Color = "Blue",
                            Gender = "Men",
                            Price = 99.950000000000003,
                            Size = 9
                        },
                        new
                        {
                            ShirtId = 2,
                            Brand = "Gucci",
                            Color = "Black",
                            Gender = "Women",
                            Price = 299.5,
                            Size = 6
                        },
                        new
                        {
                            ShirtId = 3,
                            Brand = "Nike",
                            Color = "Orange",
                            Gender = "Men",
                            Price = 59.979999999999997,
                            Size = 8
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
