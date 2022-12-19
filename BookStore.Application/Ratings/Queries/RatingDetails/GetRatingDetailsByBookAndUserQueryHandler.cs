using AutoMapper;
using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Ratings.Queries.RatingDetails
{
    public class GetRatingDetailsByBookAndUserQueryHandler
        : IRequestHandler<GetRatingDetailsByBookAndUserQuery,
            RatingDetailsByBookAndUserViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetRatingDetailsByBookAndUserQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<RatingDetailsByBookAndUserViewModel> Handle(GetRatingDetailsByBookAndUserQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Ratings
                .FirstOrDefaultAsync(r => r.UserId == request.UserId && r.BookId == request.BookId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Rating), $"uId: {request.UserId} bId: {request.BookId}");
            }

            return mapper.Map<RatingDetailsByBookAndUserViewModel>(entity);
        }
    }
}
