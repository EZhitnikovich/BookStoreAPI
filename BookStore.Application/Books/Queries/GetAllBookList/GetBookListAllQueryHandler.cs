using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Queries.GetAllBookList
{
    internal class GetBookListAllQueryHandler
        : IRequestHandler<GetBookListAllQuery, BookListAllViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetBookListAllQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BookListAllViewModel> Handle(GetBookListAllQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await context.Books
                .ProjectTo<BookAllLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BookListAllViewModel { Books = booksQuery };
        }
    }
}
