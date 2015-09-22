using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace AspNetIdentity.WebApi.Infrastructure
{
    using System.Data.Entity;

    using AspNetIdentity.WebApi.Entities;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder); 
        //    modelBuilder.Entity<ApplicationUser>().ToTable("User"); 
        //    modelBuilder.Entity<IdentityRole>().ToTable("Role"); 
        //    modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole"); 
        //    modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim"); 
        //    modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
        //}
    }
}
