using System.Data.Entity;
using GigHub.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GigHub.Persistence
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Gig> Gigs { get; set; }
        public DbSet<Attendence> Attendences { get; set; }

        public DbSet<Following> Followings { get; set; }


        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }

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
            // each attendence has one gig and each gig has many attendences
            modelBuilder.Entity<Attendence>()
                .HasRequired(a => a.Gig)
                .WithMany(g=>g.Attendences)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>().HasMany(f => f.Followers).WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<ApplicationUser>().HasMany(f => f.Followees).WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);


            modelBuilder.Entity<UserNotification>()
                .HasRequired(n => n.User)
                .WithMany(u=>u.UserNotifications)
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}