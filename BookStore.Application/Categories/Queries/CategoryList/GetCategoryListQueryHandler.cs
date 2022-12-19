using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookStore.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Categories.Queries.CategoryList
{
    internal class GetCategoryListQueryHandler
        : IRequestHandler<GetCategoryListQuery, CategoryListViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetCategoryListQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CategoryListViewModel> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Categories
                .ProjectTo<CategoryLookupDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CategoryListViewModel { Categories = entity };
        }
    }
}
