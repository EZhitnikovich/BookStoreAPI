using BookStore.Domain;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Interfaces
{
    public interface IBookStoreDbContext
    {
        DbSet<Book> Books { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Rating> Ratings { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
