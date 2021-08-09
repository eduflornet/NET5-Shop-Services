using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Author.Model;
using ShopServices.Api.Author.Persistence;

namespace ShopServices.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorBook>> { }

        public class Handler : IRequestHandler<AuthorList, List<AuthorBook>>
        {
            private readonly ContextAuthor _contextAuthor;

            public Handler(ContextAuthor contextAuthor)
            {
                _contextAuthor = contextAuthor;
            }

            public async Task<List<AuthorBook>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _contextAuthor.AuthorBook.ToListAsync();
                return authors;
            }
        }
    }
}