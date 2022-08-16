using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HMSII.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace HMSII.Data
{
    public class HMSContext : DbContext
    {
        public HMSContext() : base("HMSContext")
        {
        }

        public static HMSContext Create()
        {
            return new HMSContext();
        }

        public DbSet<AccomodationType> AccomodationTypes { get; set; }
        public DbSet<Accomodation> Accomodations { get; set; }
        public DbSet<AccomodationPackage> AccomodationPackages { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<HMSUser> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
        }
    }
}
