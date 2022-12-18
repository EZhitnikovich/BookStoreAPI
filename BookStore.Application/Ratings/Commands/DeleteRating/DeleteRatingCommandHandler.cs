﻿using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;

namespace BookStore.Application.Ratings.Commands.DeleteRating
{
    internal class DeleteRatingCommandHandler
        : IRequestHandler<DeleteRatingCommand>
    {
        private readonly IBookStoreDbContext context;

        public DeleteRatingCommandHandler(IBookStoreDbContext context)
        {
            this.context = context;
        }

        public async Task<Unit> Handle(DeleteRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.Ratings.FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }

            context.Ratings.Remove(entity);
            await context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
