namespace BookStore.Persistence
{
    public class DbInitializer
    {
        public static void Initialize(BookStoreDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
