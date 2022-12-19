using MediatR;

namespace BookStore.Application.Categories.Queries.CategoryDetails
{
    public class GetCategoryDetailsQuery: IRequest<CategoryDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
