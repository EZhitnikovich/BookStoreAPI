using MediatR;

namespace BookStore.Application.Ratings.Queries.RatingDetails
{
    internal class GetRatingDetailsQuery: IRequest<RatingDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
