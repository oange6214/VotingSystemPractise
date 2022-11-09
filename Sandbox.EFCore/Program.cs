
using Microsoft.EntityFrameworkCore;


internal class Program
{
	private static void Main(string[] args)
	{
		int orangeId = 0;

		using(var ctx = new AppDbContext())
		{
			var orange = new Fruit { Name = "Orange" };
			var apple = new Fruit { Name = "Apple" };

			ctx.Fruits.Add(orange);

			orangeId = ctx.Entry(orange).Property<int>("Id").CurrentValue;

			ctx.Fruits.Add(apple);

			ctx.SaveChanges();
		}

		using (var ctx = new AppDbContext())
		{
			var address = new Address { PostCode = "Moon"};

			ctx.Entry(address).Property<int>("FruitId").CurrentValue = orangeId;

			ctx.Addresses.Add(address);

			ctx.SaveChanges();
		}

		using (var ctx = new AppDbContext())
		{
			var fruits = ctx.Fruits
				.Include(x => x.Address)
				.Select(x => new FruitStore
				{
					Name = x.Name,
					PostCode = x.Address.PostCode ?? "UnKnown"
				})
				.ToList();

			var addresses = ctx.Addresses.ToList();
		}
	}
}