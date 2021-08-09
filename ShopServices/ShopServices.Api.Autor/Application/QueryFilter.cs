using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Author.Model;
using ShopServices.Api.Author.Persistence;

namespace ShopServices.Api.Author.Application
{
    public class QueryFilter
    {
        public class UniqueAuthor : IRequest<AuthorBook>
        {
            public string AuthorBookGuid { get; set; }
        }

        public class Handler : IRequestHandler<UniqueAuthor, AuthorBook>
        {
            private readonly ContextAuthor _contextAuthor;

            public Handler(ContextAuthor contextAuthor)
            {
                _contextAuthor = contextAuthor;
            }

            public async Task<AuthorBook> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var author = await _contextAuthor.AuthorBook.Where(x => x.AuthorBookGuid == request.AuthorBookGuid).FirstOrDefaultAsync();
                if (author == null) throw new Exception("Author not found");

                return author;
            }
        }

    }
}