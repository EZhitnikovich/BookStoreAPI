using MediatR;

namespace BookStore.Application.Books.Commands.CreateBook
{
    internal class CreateBookCommand : IRequest<Guid>
    {
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
