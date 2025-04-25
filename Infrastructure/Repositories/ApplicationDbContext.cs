using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class ApplicationDbContext(string connectionString) : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Order> Orders { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured)
			{
				return;
			}

			optionsBuilder.UseSqlServer(connectionString: connectionString);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// modelBuilder.ApplyConfiguration(new OrderConfiguration());
			// modelBuilder.ApplyConfiguration(new CustomerConfiguration());
			// modelBuilder.ApplyConfiguration(new BookConfiguration());
			
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
		}
	}
}