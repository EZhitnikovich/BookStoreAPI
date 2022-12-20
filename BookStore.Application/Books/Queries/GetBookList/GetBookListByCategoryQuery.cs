using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Books.Queries.GetBookList
{
    public class GetBookListByCategoryQuery : IRequest<BookListByCategoryViewModel>
    {
        public Guid CategoryId { get; set; }
    }
}
