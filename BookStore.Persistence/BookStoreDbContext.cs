using Microsoft.EntityFrameworkCore;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using BookStore.Persistence.EntityTypeConfigurations;

namespace BookStore.Persistence
{
    internal class BookStoreDbContext : DbContext, IBookStoreDbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public BookStoreDbContext(DbContextOptions<BookStoreDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            modelBuilder.ApplyConfiguration(new RatingConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
