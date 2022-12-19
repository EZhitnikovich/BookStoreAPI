using AutoMapper;
using BookStore.Application.Common.Exceptions;
using BookStore.Application.Interfaces;
using BookStore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Application.Books.Queries.BookDetails
{
    public class GetBookDetailsQueryHandler
        : IRequestHandler<GetBookDetailsQuery, BookDetailsViewModel>
    {
        private readonly IBookStoreDbContext context;
        private readonly IMapper mapper;

        public GetBookDetailsQueryHandler(IBookStoreDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<BookDetailsViewModel> Handle(GetBookDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await context.Books
                .FirstOrDefaultAsync(book => book.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Book), request.Id);
            }

            return mapper.Map<BookDetailsViewModel>(entity);
        }
    }
}
