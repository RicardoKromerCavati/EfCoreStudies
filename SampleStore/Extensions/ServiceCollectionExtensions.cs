using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace SampleStoreApi.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void ConfigureDependencyInjection(this IServiceCollection services)
		{
			const string appSettingsJsonFile = "appsettings.json";
			var configuration = new ConfigurationBuilder()
				.AddJsonFile(appSettingsJsonFile)
				.Build();

			services.AddControllers();
			
			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

			services.AddDbContext<ApplicationDbContext>(options =>
			{
				const string connectionStringName = "ConnectionString";
				options.UseSqlServer(configuration.GetConnectionString(connectionStringName));
			}, contextLifetime: ServiceLifetime.Scoped);
		}
	}
}