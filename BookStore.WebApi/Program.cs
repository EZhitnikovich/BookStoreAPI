using BookStore.Persistence;

namespace BookStore.WebApi;

class Program
{
	public static void Main(string[] args)
	{
		var host = CreateHostBuilder(args).Build();

		using (var scope = host.Services.CreateScope())
		{
			var serviceProvider = scope.ServiceProvider;
			try
			{
				var context = serviceProvider.GetRequiredService<BookStoreDbContext>();
				DbInitializer.Initialize(context);
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		host.Run();
	}

	private static IHostBuilder CreateHostBuilder(string[] args)
		=> Host.CreateDefaultBuilder(args)
			.ConfigureWebHostDefaults(webBuilder =>
			{
				webBuilder.UseStartup<Startup>();
			});
}