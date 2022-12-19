using MediatR;

namespace BookStore.Application.Ratings.Queries.RatingDetails
{
    public class GetRatingDetailsQuery: IRequest<RatingDetailsViewModel>
    {
        public Guid Id { get; set; }
    }
}
