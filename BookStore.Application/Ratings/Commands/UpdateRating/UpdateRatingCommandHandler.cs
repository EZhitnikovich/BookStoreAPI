using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Ratings.Commands.UpdateRating
{
    internal class UpdateRatingCommandHandler
        : IRequestHandler<UpdateRatingCommand>
    {
        private readonly IBookStoreDbContext context;

        public UpdateRatingCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(UpdateRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Ratings.
                FirstOrDefaultAsync(rating => rating.Id == request.Id, cancellationToken);

            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }

            entity.Value = request.Value;
            entity.EditDate = DateTime.Now;

            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
