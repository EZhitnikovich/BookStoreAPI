using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.Books.Commands.DeleteBook
{
    internal class DeleteBookCommandHandler
        : IRequestHandler<DeleteBookCommand>
    {
        public IBookStoreDbContext context { get; set; }

        public DeleteBookCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Books.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            context.Books.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
