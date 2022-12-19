using MediatR;

namespace BookStore.Application.Categories.Queries.CategoryList
{
    internal class GetCategoryListQuery: IRequest<CategoryListViewModel>
    {
    }
}
