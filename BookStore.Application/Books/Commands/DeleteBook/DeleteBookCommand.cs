using MediatR;

namespace BookStore.Application.Books.Commands.DeleteBook
{
    internal class DeleteBookCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
