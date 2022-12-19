using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Domain;

namespace BookStore.Application.Ratings.Queries.RatingDetails
{
    public class RatingDetailsViewModel: IMapWith<Rating>
    {
        public int Value { get; set; }
        public Guid UserId { get; set; }
        public Guid BookId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rating, RatingDetailsViewModel>()
                .ForMember(rVm => rVm.Value,
                    opt => opt.MapFrom(r => r.Value))
                .ForMember(rVm => rVm.UserId,
                    opt => opt.MapFrom(r => r.UserId))
                .ForMember(rVm => rVm.BookId,
                    opt => opt.MapFrom(r => r.BookId));
        }
    }
}
