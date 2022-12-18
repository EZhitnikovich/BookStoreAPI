using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Queries.GetAllBookList
{
    internal class GetAllBookListQueryHandler
        : IRequestHandler<GetAllBookListQuery, AllBookListViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetAllBookListQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<AllBookListViewModel> Handle(GetAllBookListQuery request, CancellationToken cancellationToken)
        {
            var booksQuery = await context.Books
                .ProjectTo<AllBookLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new AllBookListViewModel { Books = booksQuery };
        }
    }
}
