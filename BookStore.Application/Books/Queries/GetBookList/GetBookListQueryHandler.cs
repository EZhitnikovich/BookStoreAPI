using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Queries.GetBookList
{
    public class GetBookListQueryHandler
        : IRequestHandler<GetBookListQuery, BookListViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetBookListQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BookListViewModel> Handle(GetBookListQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await context.Books
                .ProjectTo<BookLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BookListViewModel { Books = booksQuery };
        }
    }
}
