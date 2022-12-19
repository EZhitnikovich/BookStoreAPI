using MediatR;

namespace BookStore.Application.Categories.Queries.CategoryDetails
{
    internal class GetCategoryDetailsQuery: IRequest<CategoryDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
