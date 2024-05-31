using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PROG7311_POE_PART_2.Models;

namespace PROG7311_POE_PART_2.DbContexts
{
    public class PROGPOEContext : Microsoft.EntityFrameworkCore.DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public PROGPOEContext(DbContextOptions<PROGPOEContext> options) : base(options)
        {

        }

        /// <summary>
        /// Db Set to store Products
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<AddProductModel> Product { get; set; }

        /// <summary>
        /// Db Set to store Users
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<UserModel> User { get; set; }

        /// <summary>
        /// Db Set to store Roles
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<Role> Roles { get; set; }

        /// <summary>
        /// Db Set to store User Roles
        /// </summary>
        public virtual Microsoft.EntityFrameworkCore.DbSet<UserRole> UserRoles{ get; set; }

        //---------------------------------------------------------------//
        /// <summary>
        /// On Model creating method for the manipulation of The Entity Framework Db sets
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AddProductModel>()
                .HasKey(e => e.ProductID); // ExternalPrimaryKey is the property in the database used as the primary key

            modelBuilder.Entity<UserRole>()
            .HasKey(ur => new { ur.UserId, ur.RoleId });

            modelBuilder.Entity<UserRole>()
            .HasOne(ur => ur.User)
            .WithMany(u => u.UserRoles)
            .HasForeignKey(ur => ur.UserId);

            modelBuilder.Entity<UserRole>()
                .HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId);
        }
        //---------------------------------------------------------------//
    }
}
//----------------------------------------------------------END OF FILE---------------------------------------------//