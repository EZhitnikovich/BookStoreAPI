using MediatR;

namespace BookStore.Application.Categories.Commands.DeleteCategory
{
    internal class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
