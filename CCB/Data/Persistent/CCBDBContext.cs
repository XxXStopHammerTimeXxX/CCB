﻿using CCB.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace CCB.Data.Persistent
{
    public partial class CCBDBContext : DbContext
    {
        public CCBDBContext()
        {
        }

        public CCBDBContext(DbContextOptions<CCBDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ccbyg.database.windows.net;Initial Catalog=CCByg;Persist Security Info=True;User ID=ccbyg;Password=Database123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AmountAllocated).HasColumnName("amountAllocated");

                entity.Property(e => e.AmountAvailable).HasColumnName("amountAvailable");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });


            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.Deadline).HasColumnName("deadline");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.IsFinished).HasColumnName("isFinished");

                entity.Property(e => e.Start).HasColumnName("start");

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Staff>(entity =>
            {
                entity.ToTable("Staff");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(200);

                entity.Property(e => e.EmployedSince).HasColumnName("employedSince");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Position)
                    .HasColumnName("position")
                    .HasMaxLength(50);

                entity.Property(e => e.Telephone)
                    .HasColumnName("telephone")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Domain.Item>().Ignore(item => item.Key);
            modelBuilder.Entity<Domain.Project>().Ignore(item => item.Key);
            modelBuilder.Entity<Domain.Staff>().Ignore(item => item.Key);

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
