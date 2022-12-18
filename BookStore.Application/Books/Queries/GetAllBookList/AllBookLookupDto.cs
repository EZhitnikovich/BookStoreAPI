using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Domain;

namespace BookStore.Application.Books.Queries.GetAllBookList
{
    internal class AllBookLookupDto: IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string CategoryName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, AllBookLookupDto>()
                .ForMember(bookDto => bookDto.Title,
                    opt => opt.MapFrom(book => book.Title))
                .ForMember(bookDto => bookDto.Description,
                    opt => opt.MapFrom(book => book.Description))
                .ForMember(bookDto => bookDto.Price,
                    opt => opt.MapFrom(book => book.Price))
                .ForMember(bookDto => bookDto.Id,
                    opt => opt.MapFrom(book => book.Id))
                .ForMember(bookDto => bookDto.CategoryName,
                    opt => opt.MapFrom(book => book.Category.Title));
        }
    }
}
