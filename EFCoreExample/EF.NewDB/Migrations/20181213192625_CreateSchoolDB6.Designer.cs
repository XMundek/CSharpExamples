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
    [Migration("20181213192625_CreateSchoolDB6")]
    partial class CreateSchoolDB6
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

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

            modelBuilder.Entity("EF.NewDB.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("GradeId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("GradeId");

                    b.ToTable("Students");
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

            modelBuilder.Entity("EF.NewDB.Student", b =>
                {
                    b.HasOne("EF.NewDB.Grade", "Grade")
                        .WithMany("Students")
                        .HasForeignKey("GradeId");
                });

            modelBuilder.Entity("EF.NewDB.T", b =>
                {
                    b.HasOne("EF.NewDB.T1", "DD")
                        .WithMany()
                        .HasForeignKey("DDId");
                });
#pragma warning restore 612, 618
        }
    }
}
