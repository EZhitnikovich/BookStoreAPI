namespace BookStore.Domain;

internal class Book : Entity
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public string Desctiption { get; set; }

}
