﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Proxies;
namespace Challenge
{
    public partial class ChallengeDBContext : DbContext
    {
        public ChallengeDBContext()
        {
        }

        public ChallengeDBContext(DbContextOptions<ChallengeDBContext> options)
            : base(options)
        {
            Students.Include(x => x.StudentPaids);
        }

        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentPaid> StudentPaids { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=localhost;Initial Catalog=ChallengeDB;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(e => e.StudentID).ValueGeneratedNever();
            });

            modelBuilder.Entity<StudentPaid>(entity =>
            {
                entity.Property(e => e.StudentPaidID).ValueGeneratedNever();

                entity.HasOne(d => d.Student)
                    .WithMany(p => p.StudentPaids)
                    .HasForeignKey(d => d.StudentID)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StudentPaid_Students");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}