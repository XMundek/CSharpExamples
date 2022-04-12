﻿// <auto-generated />
using System;
using EF.NewDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EF.NewDB.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20181216015207_CreateSchoolDB25")]
    partial class CreateSchoolDB25
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("School")
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EF.NewDB.Author", b =>
                {
                    b.Property<int>("AuthorId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("AuthorId");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("EF.NewDB.AuthorBiography", b =>
                {
                    b.Property<int>("AuthorBiographyId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorId");

                    b.Property<string>("Biography");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Nationality");

                    b.Property<string>("PlaceOfBirth");

                    b.HasKey("AuthorBiographyId");

                    b.HasIndex("AuthorId")
                        .IsUnique();

                    b.ToTable("AuthorBiography");
                });

            modelBuilder.Entity("EF.NewDB.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuthorId");

                    b.Property<string>("Title");

                    b.HasKey("BookId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("EF.NewDB.BookCategory", b =>
                {
                    b.Property<int>("BookId");

                    b.Property<int>("CategoryId");

                    b.HasKey("BookId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Category","dictionary");
                });

            modelBuilder.Entity("EF.NewDB.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.HasKey("CategoryId");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("EF.NewDB.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("EF.NewDB.Grade", b =>
                {
                    b.Property<int>("GradeId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("GradeName");

                    b.HasKey("GradeId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("EF.NewDB.PersonTph", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<byte>("Type");

                    b.HasKey("Id");

                    b.ToTable("Person");

                    b.HasDiscriminator<byte>("Type").HasValue((byte)0);
                });

            modelBuilder.Entity("EF.NewDB.PersonTpt", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.ToTable("PersonT");

                    b.HasDiscriminator<string>("Discriminator").HasValue("PersonTpt");
                });

            modelBuilder.Entity("EF.NewDB.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreateDT")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("GetDate()");

                    b.Property<int?>("GradeId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("StdName")
                        .IsFixedLength(true)
                        .HasMaxLength(300);

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("EF.NewDB.StudentX", b =>
                {
                    b.Property<int>("SID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("StdId");

                    b.Property<string>("StudentName")
                        .HasColumnName("Name")
                        .HasColumnType("ntext")
                        .HasMaxLength(20);

                    b.HasKey("SID");

                    b.HasIndex("StdId");

                    b.ToTable("StudentInfo");
                });

            modelBuilder.Entity("EF.NewDB.T", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DDId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DDId");

                    b.ToTable("XX");
                });

            modelBuilder.Entity("EF.NewDB.T1", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("T1");
                });

            modelBuilder.Entity("EF.NewDB.CustomerTph", b =>
                {
                    b.HasBaseType("EF.NewDB.PersonTph");

                    b.Property<DateTime>("DateOfBirth");

                    b.HasDiscriminator().HasValue((byte)1);
                });

            modelBuilder.Entity("EF.NewDB.EmployeeTph", b =>
                {
                    b.HasBaseType("EF.NewDB.PersonTph");

                    b.Property<decimal>("Salary");

                    b.HasDiscriminator().HasValue((byte)2);
                });

            modelBuilder.Entity("EF.NewDB.CustomerTpt", b =>
                {
                    b.HasBaseType("EF.NewDB.PersonTpt");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<Guid?>("PersonId");

                    b.HasIndex("PersonId");

                    b.HasDiscriminator().HasValue("CustomerTpt");
                });

            modelBuilder.Entity("EF.NewDB.EmployeeTpt", b =>
                {
                    b.HasBaseType("EF.NewDB.PersonTpt");

                    b.Property<Guid?>("PersonId")
                        .HasColumnName("EmployeeTpt_PersonId");

                    b.Property<decimal>("Salary");

                    b.HasIndex("PersonId");

                    b.HasDiscriminator().HasValue("EmployeeTpt");
                });

            modelBuilder.Entity("EF.NewDB.AuthorBiography", b =>
                {
                    b.HasOne("EF.NewDB.Author", "Author")
                        .WithOne("Biography")
                        .HasForeignKey("EF.NewDB.AuthorBiography", "AuthorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EF.NewDB.Book", b =>
                {
                    b.HasOne("EF.NewDB.Author", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId");
                });

            modelBuilder.Entity("EF.NewDB.BookCategory", b =>
                {
                    b.HasOne("EF.NewDB.Book", "Book")
                        .WithMany("BookCategories")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EF.NewDB.Category", "Category")
                        .WithMany("BookCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EF.NewDB.Student", b =>
                {
                    b.HasOne("EF.NewDB.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId");
                });

            modelBuilder.Entity("EF.NewDB.StudentX", b =>
                {
                    b.HasOne("EF.NewDB.Course", "Standard")
                        .WithMany()
                        .HasForeignKey("StdId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EF.NewDB.T", b =>
                {
                    b.HasOne("EF.NewDB.T1", "DD")
                        .WithMany()
                        .HasForeignKey("DDId");
                });

            modelBuilder.Entity("EF.NewDB.CustomerTpt", b =>
                {
                    b.HasOne("EF.NewDB.PersonTpt", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("EF.NewDB.EmployeeTpt", b =>
                {
                    b.HasOne("EF.NewDB.PersonTpt", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");
                });
#pragma warning restore 612, 618
        }
    }
}
