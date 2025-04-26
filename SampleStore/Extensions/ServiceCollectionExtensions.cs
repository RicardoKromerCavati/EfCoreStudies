using Core.Entities;
using Core.Repositories;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SampleStoreApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			services.AddControllers();

			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.ConfigureDatabase();
			services.ConfigureRepositories();
		}

		private static void ConfigureRepositories(this IServiceCollection services)
		{
			services.AddScoped<ICustomerRepository, CustomerRepository>();
			services.AddScoped<IBookRepository, BookRepository>();
			services.AddScoped<IOrderRepository, OrderRepository>();
		}

		private static void ConfigureDatabase(this IServiceCollection services)
		{
			const string appSettingsJsonFile = "appsettings.json";

			var configuration = new ConfigurationBuilder()
				.AddJsonFile(appSettingsJsonFile)
				.Build();

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				const string connectionStringName = "ConnectionString";
				options
				.UseSqlServer(configuration.GetConnectionString(connectionStringName));
			}, contextLifetime: ServiceLifetime.Scoped);
		}
	}

}