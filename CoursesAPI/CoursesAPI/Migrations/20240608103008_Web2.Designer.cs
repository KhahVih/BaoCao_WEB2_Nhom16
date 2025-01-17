﻿// <auto-generated />
using System;
using CoursesAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CoursesAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240608103008_Web2")]
    partial class Web2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CoursesAPI.Model.Domain.Courses", b =>
                {
                    b.Property<int>("CoursesID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CoursesID"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CoursesID");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CoursesID = 1,
                            Description = "Learn the basics of programming with Python.",
                            EndDate = new DateTime(2024, 4, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Ongoing",
                            Title = "Introduction to Programming"
                        },
                        new
                        {
                            CoursesID = 2,
                            Description = "Learn how to build modern web applications.",
                            EndDate = new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartDate = new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Status = "Upcoming",
                            Title = "Web Development"
                        });
                });

            modelBuilder.Entity("CoursesAPI.Model.Domain.CoursesStudent", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("CoursesID")
                        .HasColumnType("int");

                    b.Property<int>("StudentID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CoursesID");

                    b.HasIndex("StudentID");

                    b.ToTable("CoursesStudents");
                });

            modelBuilder.Entity("CoursesAPI.Model.Domain.Student", b =>
                {
                    b.Property<int>("StudentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentID"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phones")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudentName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentID");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentID = 1,
                            Email = "nguyenvana@gmail.com",
                            Phones = "0123456789",
                            StudentName = "Nguyễn Văn A"
                        },
                        new
                        {
                            StudentID = 2,
                            Email = "tranthib@gmail.com",
                            Phones = "0987654321",
                            StudentName = "Trần Thị B"
                        });
                });

            modelBuilder.Entity("CoursesAPI.Model.Domain.CoursesStudent", b =>
                {
                    b.HasOne("CoursesAPI.Model.Domain.Courses", "Courses")
                        .WithMany("CoursesStudent")
                        .HasForeignKey("CoursesID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CoursesAPI.Model.Domain.Student", "Student")
                        .WithMany("CourseStudents")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Courses");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CoursesAPI.Model.Domain.Courses", b =>
                {
                    b.Navigation("CoursesStudent");
                });

            modelBuilder.Entity("CoursesAPI.Model.Domain.Student", b =>
                {
                    b.Navigation("CourseStudents");
                });
#pragma warning restore 612, 618
        }
    }
}
