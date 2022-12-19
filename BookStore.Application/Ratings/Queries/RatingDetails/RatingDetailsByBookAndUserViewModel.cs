using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Domain;

namespace BookStore.Application.Ratings.Queries.RatingDetails
{
    internal class RatingDetailsByBookAndUserViewModel : IMapWith<Rating>
    {
        public Guid Id { get; set; }
        public int Value { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Rating, RatingDetailsByBookAndUserViewModel>()
                .ForMember(rVm => rVm.Id,
                    opt => opt.MapFrom(r => r.Id))
                .ForMember(rVm => rVm.Value,
                    opt => opt.MapFrom(r => r.Value));
        }
    }
}
