using MediatR;

namespace BookStore.Application.Categories.Queries.CategoryList
{
    public class GetCategoryListQuery: IRequest<CategoryListViewModel>
    {
    }
}
