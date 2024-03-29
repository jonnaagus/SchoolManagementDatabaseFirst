﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SchoolManagementDatabaseFirst.Models
{
    public partial class SchoolDatabaseContext : DbContext
    {
        public SchoolDatabaseContext()
        {
        }

        public SchoolDatabaseContext(DbContextOptions<SchoolDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<Enroll> Enrolls { get; set; } = null!;
        public virtual DbSet<GivesGrade> GivesGrades { get; set; } = null!;
        public virtual DbSet<Grade> Grades { get; set; } = null!;
        public virtual DbSet<Principal> Principals { get; set; } = null!;
        public virtual DbSet<Staff> Staffs { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Teacher> Teachers { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=SchoolDatabase;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.CourseID)
                    .ValueGeneratedNever()
                    .HasColumnName("CourseID");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Enroll>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FKCourseID).HasColumnName("FKCourseID");

                entity.Property(e => e.FKStudentID).HasColumnName("FKStudentID");
            });

            modelBuilder.Entity<GivesGrade>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.FKCourseID).HasColumnName("FKCourseID");

                entity.Property(e => e.FKGradeID).HasColumnName("FKGradeID");

                entity.Property(e => e.FKStudentID).HasColumnName("FKStudentID");

                entity.Property(e => e.FKTeacherID).HasColumnName("FKTeacherID");

                entity.Property(e => e.GradeDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasIndex(e => e.FKCourseID, "IX_Grades_FKCourseID");
                entity.HasIndex(e => e.FKStudentID, "IX_Grades_FKStudentID");
                entity.Property(e => e.GradeId).ValueGeneratedOnAdd(); // För autoinkrementerande kolumn
                entity.Property(e => e.GradeId).ValueGeneratedNever().HasColumnName("GradeID");
                entity.Property(e => e.FKCourseID).HasColumnName("FKCourseID");
                entity.Property(e => e.FKStudentID).HasColumnName("FKStudentID");
                entity.Property(e => e.FKTeacherID).HasColumnName("FKTeacherID"); 
                entity.Property(e => e.GradeDate).HasColumnType("date");
                entity.Property(e => e.GradeValue).HasMaxLength(10).IsUnicode(false);

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FKCourseID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FKStudentID)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Teacher)
                    .WithMany(p => p.Grades)
                    .HasForeignKey(d => d.FKTeacherID);
            });

            modelBuilder.Entity<Principal>(entity =>
            {
                entity.ToTable("Principal");

                entity.Property(e => e.PrincipalID)
                    .ValueGeneratedNever()
                    .HasColumnName("PrincipalID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.Property(e => e.StaffID)
                    .ValueGeneratedNever()
                    .HasColumnName("StaffID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.StudentID)
                    .ValueGeneratedNever()
                    .HasColumnName("StudentID");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalIDNr)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("PersonalIDNr");
            });

            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.Property(e => e.TeacherID)
                    .ValueGeneratedNever()
                    .HasColumnName("TeacherID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Position)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.StartDate).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
