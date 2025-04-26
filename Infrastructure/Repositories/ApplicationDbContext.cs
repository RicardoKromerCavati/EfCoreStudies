using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Infrastructure.Repositories
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Order> Orders { get; set; }

		private readonly string _connectionString;

		public ApplicationDbContext()
		{
			
		}

		public ApplicationDbContext(string connectionString)
		{
			_connectionString = connectionString;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured)
			{
				return;
			}

			optionsBuilder.UseSqlServer(connectionString: _connectionString);
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