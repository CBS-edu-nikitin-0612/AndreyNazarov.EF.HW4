using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Task1.Models
{
    public partial class MyJoinsDBContext : DbContext
    {
        public MyJoinsDBContext()
        {
        }

        public MyJoinsDBContext(DbContextOptions<MyJoinsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<StaffDetail> StaffDetails { get; set; } = null!;
        public virtual DbSet<Staff> Staff { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-C6B349A;Database=MyJoinsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>(entity =>
            {
                entity.Property(e => e.Position1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Position");

                entity.Property(e => e.Salary).HasColumnType("decimal(5, 2)");
            });

            modelBuilder.Entity<StaffDetail>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.MaritalStatus)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Postion)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.PostionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_PostionId");

                entity.HasOne(d => d.StaffDetails)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.StaffDetailsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Staff_StaffDetailsId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
