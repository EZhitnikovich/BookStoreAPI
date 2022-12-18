using MediatR;

namespace BookStore.Application.Categories.Commands.CreateCommand
{
    internal class CreateCategoryCommand: IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
