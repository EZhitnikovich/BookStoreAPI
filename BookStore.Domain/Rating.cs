namespace BookStore.Domain
{
    internal class Rating: Entity
    {
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }
        public int Value { get; set; }
    }
}
