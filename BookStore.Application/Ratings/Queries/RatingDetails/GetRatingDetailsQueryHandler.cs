using AutoMapper;
using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Ratings.Queries.RatingDetails
{
    internal class GetRatingDetailsQueryHandler
        : IRequestHandler<GetRatingDetailsQuery, RatingDetailsViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetRatingDetailsQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RatingDetailsViewModel> Handle(GetRatingDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Ratings
                .FirstOrDefaultAsync(r => r.Id == request.Id, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), request.Id);
            }

            return mapper.Map<RatingDetailsViewModel>(entity);
        }
    }
}
