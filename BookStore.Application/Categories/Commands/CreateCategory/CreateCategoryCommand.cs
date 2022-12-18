using MediatR;

namespace BookStore.Application.Categories.Commands.CreateCategory
{
    internal class CreateCategoryCommand: IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
