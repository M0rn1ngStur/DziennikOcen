using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DziennikOcen.Model
{
    public partial class DziennikOcenContext : DbContext
    {
        public DziennikOcenContext()
        {
        }

        public DziennikOcenContext(DbContextOptions<DziennikOcenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attendance> Attendances { get; set; } = null!;
        public virtual DbSet<Class> Classes { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=DziennikOcen;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>(entity =>
            {
                entity.ToTable("Attendance");

                entity.Property(e => e.Attendance1).HasColumnName("attendance");

                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("date");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Attendances)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Attendance_ToClass");
            });

            modelBuilder.Entity<Class>(entity =>
            {
                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("className");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.Property(e => e.ClassId).HasColumnName("classId");

                entity.Property(e => e.Grade1).HasColumnName("grade");

                entity.Property(e => e.StudentId).HasColumnName("studentId");

                entity.HasOne(d => d.Class)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.ClassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Classes");

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.StudentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Grades_Students");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.GroupSymbol)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("groupSymbol");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
