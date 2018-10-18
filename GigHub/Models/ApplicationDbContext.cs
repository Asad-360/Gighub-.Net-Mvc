﻿using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Attendence> Attendences { get; set; }

        public DbSet<Following> Followings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendence>().HasRequired(a => a.Gig).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Following>().HasRequired(f => f.Artist).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}