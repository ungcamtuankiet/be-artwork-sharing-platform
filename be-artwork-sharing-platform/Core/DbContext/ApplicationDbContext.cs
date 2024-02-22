using be_artwork_sharing_platform.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Reflection.Emit;

namespace be_artwork_sharing_platform.Core.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Log> Logs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Artwork> Artworks { get; set; }
        public DbSet<Favourite> Favorites { get; set; }
        public DbSet<RequestOrder> RequestOrders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //1
            builder.Entity<ApplicationUser>(e =>
            {
                e.ToTable("users");
            });
            //2
            builder.Entity<IdentityUserClaim<string>>(e =>
            {
                e.ToTable("userclaims");
            });
            //3
            builder.Entity<IdentityUserLogin<string>>(e =>
            {
                e.ToTable("userlogins");
            });
            //4
            builder.Entity<IdentityUserToken<string>>(e =>
            {
                e.ToTable("usertokens");
            });
            //5
            builder.Entity<IdentityRole>(e =>
            {
                e.ToTable("roles");
            });
            //6
            builder.Entity<IdentityRoleClaim<string>>(e =>
            {
                e.ToTable("roleclaims");
            });
            //7
            builder.Entity<IdentityUserRole<string>>(e =>
            {
                e.ToTable("userroles");
            });

            builder.Entity<Log>(e =>
            {
                e.ToTable("logs");
            });

            builder.Entity<Category>()
                .HasMany(c => c.Artworks)
                .WithOne(a => a.Category)
                .HasForeignKey(c => c.Id);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Comments)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.User_Id);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Payments)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.User_Id);

            builder.Entity<ApplicationUser>()
                .HasMany(u => u.Favourites)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.User_Id);

            builder.Entity<Artwork>()
               .HasMany(a => a.Comments)
               .WithOne(c => c.Artwork)
               .HasForeignKey(c => c.Artwork_Id);

            builder.Entity<Favourite>()
                .HasOne(f => f.Artwork)
                .WithMany(a => a.Favourite)
                .HasForeignKey(f => f.Artwork_Id);
        }
    }
}
