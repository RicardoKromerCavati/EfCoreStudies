using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.Extensions.Configuration;

namespace Infrastructure
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Book> Books { get; set; }
		public DbSet<Order> Orders { get; set; }

		private readonly string _connectionString;

		public ApplicationDbContext()
		{
			IConfiguration configuration = new ConfigurationBuilder()
				.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
				.AddJsonFile("appsettings.json")
				.Build();

			_connectionString = configuration.GetConnectionString("ConnectionString")!;
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

			optionsBuilder
				.UseSqlServer(connectionString: _connectionString);
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