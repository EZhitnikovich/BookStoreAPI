using AutoMapper;
using BookStore.Application.Books.Commands.UpdateBook;
using BookStore.Application.Common.Mapping;

namespace BookStore.WebApi.Models
{
    public class UpdateBookDto: IMapWith<UpdateBookCommand>
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Price { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateBookDto, UpdateBookCommand>();
        }
    }
}
