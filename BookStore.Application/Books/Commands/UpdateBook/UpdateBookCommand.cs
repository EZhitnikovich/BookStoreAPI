using MediatR;

namespace BookStore.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommand: IRequest
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
