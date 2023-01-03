using Microsoft.EntityFrameworkCore;

namespace Backend_Thue.Data;

public class MyDbContext: DbContext
{
    public MyDbContext(DbContextOptions options): base(options){}

    #region Dbset
    public DbSet<User> Users { get; set; }
    public DbSet<Coffee> Coffees { get; set; }
    public DbSet<Cart> Carts { get; set; }
    public DbSet<CartDetail> CartDetails { get; set; }
    public DbSet<Favourite> Favourites { get; set; }
    public DbSet<FavouriteDetail> FavouriteDetails { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CartDetail>().HasIndex(e => new { e.CoffeeId, e.CartId }).IsUnique();
        modelBuilder.Entity<FavouriteDetail>().HasIndex(e => new { e.FavouriteId, e.CoffeeId }).IsUnique();
    }

    #endregion
}