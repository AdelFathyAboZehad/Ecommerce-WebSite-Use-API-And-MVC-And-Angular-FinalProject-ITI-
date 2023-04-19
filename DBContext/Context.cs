using Domian;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;

namespace DbContextL
{
    public class Context:IdentityDbContext<User,Role,int>
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().ToTable("User");
            builder.Entity<Role>().ToTable("Role");
            builder.Entity<IdentityUserRole<int>>().ToTable("UserRole");
            builder.Entity<IdentityUserClaim<int>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<int>>().ToTable("UserLogin");
            builder.Entity<IdentityRoleClaim<int>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<int>>().ToTable("UserToken");
        }

        // public DbSet<User> Users { get; set; }
        public DbSet<Address> Address { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<UserReview> UserReviews { get; set; }
        public DbSet<UserPaymetMethod> UserPaymetMethods { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ShoppingMethod> ShoppingMethods { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Image> Images { get; set; }

        public DbSet<WishList> WishLists { get; set; }
        public DbSet<Variation> Variations { get; set; }
        public DbSet<VariationOption> VariationOptions { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Stock> Stocks { get; set; }




    }
}
