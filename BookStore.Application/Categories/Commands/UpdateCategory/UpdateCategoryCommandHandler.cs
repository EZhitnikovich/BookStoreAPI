using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.Categories.Commands.UpdateCategory
{
    internal class UpdateCategoryCommandHandler
        : IRequestHandler<UpdateCategoryCommand>
    {
        private readonly IBookStoreDbContext context;

        public UpdateCategoryCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Categories.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Category), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.EditDate = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
