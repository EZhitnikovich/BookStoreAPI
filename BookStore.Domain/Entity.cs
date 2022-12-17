namespace BookStore.Domain;

public class Entity
{
    public Guid Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? EditDate { get; set; }
}
