namespace BookStore.Domain;

public class Book : Entity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }

    public Guid CategoryId { get; set; }
    public Category Category { get; set; }

    public List<Rating> Ratings { get; set; }
}
