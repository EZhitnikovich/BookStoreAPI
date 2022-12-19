using AutoMapper;
using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Categories.Queries.CategoryDetails
{
    internal class GetCategoryDetailsQueryHandler
        : IRequestHandler<GetCategoryDetailsQuery, CategoryDetailsViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetCategoryDetailsQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<CategoryDetailsViewModel> Handle(GetCategoryDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Categories
                .FirstOrDefaultAsync(categ => categ.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            return mapper.Map<CategoryDetailsViewModel>(entity);
        }
    }
}
