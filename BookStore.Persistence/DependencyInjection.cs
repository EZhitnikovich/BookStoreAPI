using BookStore.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookStore.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
                                                    IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            services.AddDbContext<BookStoreDbContext>(opt =>
            {
                opt.UseSqlite(connectionString);
            });

            services.AddScoped<IBookStoreDbContext, BookStoreDbContext>(); //TODO
            return services;
        }
    }
}
