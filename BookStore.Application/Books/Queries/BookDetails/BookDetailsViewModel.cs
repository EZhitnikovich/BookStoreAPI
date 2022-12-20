using AutoMapper;
using BookStore.Application.Common.Mapping;
using BookStore.Domain;

namespace BookStore.Application.Books.Queries.BookDetails
{
    public class BookDetailsViewModel : IMapWith<Book>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Guid CategoryId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsViewModel>()
                .ForMember(bookVm => bookVm.Title,
                    opt => opt.MapFrom(book => book.Title))
                .ForMember(bookVm => bookVm.Description,
                    opt => opt.MapFrom(book => book.Description))
                .ForMember(bookVm => bookVm.Price,
                    opt => opt.MapFrom(book => book.Price))
                .ForMember(bookVm => bookVm.CategoryId,
                    opt => opt.MapFrom(book => book.CategoryId))
                .ForMember(bookVm => bookVm.CreationDate,
                    opt => opt.MapFrom(book => book.CreationDate))
                .ForMember(bookVm => bookVm.EditDate,
                    opt => opt.MapFrom(book => book.EditDate))
                .ForMember(bookVm => bookVm.Id,
                    opt => opt.MapFrom(book => book.Id));
        }
    }
}
