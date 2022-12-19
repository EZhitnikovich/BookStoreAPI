using BookStore.Application.Common.Mapping;
using MediatR;

namespace BookStore.Application.Books.Queries.BookDetails
{
    public class GetBookDetailsQuery : IRequest<BookDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
