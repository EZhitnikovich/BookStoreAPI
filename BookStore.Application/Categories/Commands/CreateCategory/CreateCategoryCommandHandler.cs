using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.Categories.Commands.CreateCategory
{
    internal class CreateCategoryCommandHandler
        : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly IBookStoreDbContext context;

        public CreateCategoryCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Title = request.Title,
                Description = request.Description,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null
            };

            await context.Categories.AddAsync(category, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            return category.Id;
        }
    }
}
