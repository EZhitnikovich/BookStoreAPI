using MediatR;

namespace BookStore.Application.Ratings.Queries.RatingDetails
{
    internal class GetRatingDetailsByBookAndUserQuery: IRequest<RatingDetailsByBookAndUserViewModel>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
    }
}
