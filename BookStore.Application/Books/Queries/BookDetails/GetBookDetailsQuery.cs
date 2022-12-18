using BookStore.Application.Common.Mapping;
using MediatR;

namespace BookStore.Application.Books.Queries.BookDetails
{
    internal class GetBookDetailsQuery : IRequest<BookDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
