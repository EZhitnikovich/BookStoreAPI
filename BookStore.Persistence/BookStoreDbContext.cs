using Microsoft.EntityFrameworkCore;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using BookStore.Persistence.EntityTypeConfigurations;

namespace BookStore.Persistence
{
    public class BookStoreDbContext : DbContext, IBookStoreDbContext
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

            modelBuilder.Entity<Book>()
                .HasOne(b => b.Category)
                .WithMany(c => c.Books)
                .HasForeignKey(k => k.CategoryId);

            modelBuilder.Entity<Rating>()
                .HasOne(r => r.Book)
                .WithMany(b => b.Ratings)
                .HasForeignKey(k => k.BookId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
