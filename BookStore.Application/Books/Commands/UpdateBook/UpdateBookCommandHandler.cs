using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Commands.UpdateBook
{
    public class UpdateBookCommandHandler
        : IRequestHandler<UpdateBookCommand>
    {
        private readonly IBookStoreDbContext context;

        public UpdateBookCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Books
                .FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.Price= request.Price;
            entity.CategoryId = request.CategoryId;
            entity.EditDate = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
