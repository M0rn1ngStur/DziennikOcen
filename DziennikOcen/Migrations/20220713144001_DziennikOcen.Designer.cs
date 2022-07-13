﻿// <auto-generated />
using System;
using DziennikOcen.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DziennikOcen.Migrations
{
    [DbContext(typeof(DziennikOcenContext))]
    [Migration("20220713144001_DziennikOcen")]
    partial class DziennikOcen
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DziennikOcen.Model.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool>("Attendance1")
                        .HasColumnType("bit")
                        .HasColumnName("attendance");

                    b.Property<int>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("classId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.ToTable("Attendance", (string)null);
                });

            modelBuilder.Entity("DziennikOcen.Model.Class", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClassName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("className");

                    b.HasKey("Id");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("DziennikOcen.Model.Grade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("ClassId")
                        .HasColumnType("int")
                        .HasColumnName("classId");

                    b.Property<int>("Grade1")
                        .HasColumnType("int")
                        .HasColumnName("grade");

                    b.Property<int>("StudentId")
                        .HasColumnType("int")
                        .HasColumnName("studentId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("StudentId");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("DziennikOcen.Model.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("GroupSymbol")
                        .IsRequired()
                        .HasMaxLength(3)
                        .IsUnicode(false)
                        .HasColumnType("varchar(3)")
                        .HasColumnName("groupSymbol");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("DziennikOcen.Model.Attendance", b =>
                {
                    b.HasOne("DziennikOcen.Model.Class", "Class")
                        .WithMany("Attendances")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("FK_Attendance_ToClass");

                    b.Navigation("Class");
                });

            modelBuilder.Entity("DziennikOcen.Model.Grade", b =>
                {
                    b.HasOne("DziennikOcen.Model.Class", "Class")
                        .WithMany("Grades")
                        .HasForeignKey("ClassId")
                        .IsRequired()
                        .HasConstraintName("FK_Grades_Classes");

                    b.HasOne("DziennikOcen.Model.Student", "Student")
                        .WithMany("Grades")
                        .HasForeignKey("StudentId")
                        .IsRequired()
                        .HasConstraintName("FK_Grades_Students");

                    b.Navigation("Class");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("DziennikOcen.Model.Class", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Grades");
                });

            modelBuilder.Entity("DziennikOcen.Model.Student", b =>
                {
                    b.Navigation("Grades");
                });
#pragma warning restore 612, 618
        }
    }
}
