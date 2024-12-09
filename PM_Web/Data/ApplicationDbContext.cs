﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PM.Models;

namespace PM.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<ApplicationUser> Users { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<ScopePackage> ScopePackages { get; set; }
        public virtual DbSet<BOQ> BOQs { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<InterfacePoint> InterfacePoints { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<InterfaceAgreement> InterfaceAgreements { get; set; }
        public virtual DbSet<Documentation> Documentations { get; set; }
        public virtual DbSet<ScopePackageDepartment> ScopePackageDepartments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InterfacePoint>()
                .HasMany(ip => ip.Chat)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InterfacePoint>()
                .HasMany(ip => ip.Documentations)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InterfacePoint>()
                .HasMany(ip => ip.BOQs)
                .WithMany(boq => boq.InterfacePoints);

            modelBuilder.Entity<InterfacePoint>()
                .HasMany(ip => ip.Activities)
                .WithMany(act => act.InterfacePoints);

            modelBuilder.Entity<InterfaceAgreement>()
                .HasMany(ip => ip.Chat)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InterfaceAgreement>()
                .HasMany(ip => ip.Documentations)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<InterfacePoint>()
                .HasOne(ip => ip.Project)
                .WithMany(p => p.InterfacePoints)
                .HasForeignKey(ip => ip.ProjectId);

            modelBuilder.Entity<InterfacePoint>()
                .HasOne(ip => ip.System1)
                .WithMany()
                .HasForeignKey(ip => ip.System1Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InterfacePoint>()
                .HasOne(ip => ip.System2)
                .WithMany()
                .HasForeignKey(ip => ip.System2Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InterfacePoint>()
                .HasOne(ip => ip.ScopePackage1)
                .WithMany()
                .HasForeignKey(ip => ip.ScopePackage1Id)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<InterfacePoint>()
                .HasOne(ip => ip.ScopePackage2)
                .WithMany()
                .HasForeignKey(ip => ip.ScopePackage2Id)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }

}
