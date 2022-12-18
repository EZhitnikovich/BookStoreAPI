using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Queries.GetBookListByCategory
{
    internal class GetBookListByCategoryQueryHandler
        : IRequestHandler<GetBookListByCategoryQuery, BookListByCategoryViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetBookListByCategoryQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BookListByCategoryViewModel> Handle(GetBookListByCategoryQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await context.Books
                .Where(book => book.CategoryId == request.CategoryId)
                .ProjectTo<BookLookupByCategoryDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BookListByCategoryViewModel { Books = booksQuery };
        }
    }
}
