using MediatR;

namespace BookStore.Application.Books.Queries.GetAllBookList
{
    internal class GetBookListQuery: IRequest<BookListAllViewModel>
    {

    }
}
