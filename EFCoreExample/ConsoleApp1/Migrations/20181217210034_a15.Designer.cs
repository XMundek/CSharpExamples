﻿// <auto-generated />
using System;
using EF.Query;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF.Query.Migrations
{
    [DbContext(typeof(ProductDbContext))]
    [Migration("20181217210034_a15")]
    partial class a15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF.Query.Category", b =>
                {
                    b.Property<int>("Id");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "C1"
                        },
                        new
                        {
                            Id = 2,
                            Name = "C2"
                        });
                });

            modelBuilder.Entity("EF.Query.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<byte[]>("RowVersion");

                    b.Property<int>("SubCategoryId");

                    b.HasKey("Id");

                    b.HasIndex("SubCategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "P1",
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "P2",
                            SubCategoryId = 1
                        },
                        new
                        {
                            Id = 3,
                            Name = "P3",
                            SubCategoryId = 2
                        },
                        new
                        {
                            Id = 4,
                            Name = "P4",
                            SubCategoryId = 4
                        });
                });

            modelBuilder.Entity("EF.Query.SubCategory", b =>
                {
                    b.Property<int>("Id");

                    b.Property<int>("CategoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("SubCategories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Name = "S1"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 1,
                            Name = "S2"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Name = "S3"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 2,
                            Name = "S4"
                        });
                });

            modelBuilder.Entity("EF.Query.Product", b =>
                {
                    b.HasOne("EF.Query.SubCategory", "SubCategory")
                        .WithMany("Products")
                        .HasForeignKey("SubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EF.Query.SubCategory", b =>
                {
                    b.HasOne("EF.Query.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
