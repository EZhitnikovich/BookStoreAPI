using AutoMapper;
using BookStore.Application.Books.Commands.CreateBook;
using BookStore.Application.Common.Mapping;

namespace BookStore.WebApi.Models
{
    public class CreateBookDto: IMapWith<CreateBookCommand>
    {
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateBookDto, CreateBookCommand>()
                .ForMember(d => d.CategoryId,
                    opt => opt.MapFrom(c => c.CategoryId))
                .ForMember(d => d.Title,
                    opt => opt.MapFrom(c=> c.Title))
                .ForMember(d => d.Description,
                    opt => opt.MapFrom(c=> c.Description))
                .ForMember(d => d.Price, 
                    opt => opt.MapFrom(c => c.Price));
        }
    }
}
