namespace BookStore.Domain;

public class Category: Entity
{
    public string Title { get; set; }
    public string Description { get; set; }

    public List<Book> Books { get; set; }
}
