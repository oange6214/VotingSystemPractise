
using Microsoft.EntityFrameworkCore;
public class AppDbContext : DbContext
{
	public DbSet<Fruit> Fruits { get; set; }
	public DbSet<Address> Addresses { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<Fruit>().Property<int>("Id");
		modelBuilder.Entity<Address>().Property<int>("FruitId");
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseInMemoryDatabase("Database");
	}
}
