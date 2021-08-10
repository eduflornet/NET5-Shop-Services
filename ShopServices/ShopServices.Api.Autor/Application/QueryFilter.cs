using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Author.Model;
using ShopServices.Api.Author.Persistence;

namespace ShopServices.Api.Author.Application
{
    public class QueryFilter
    {
        public class UniqueAuthor : IRequest<AuthorDto>
        {
            public string AuthorBookGuid { get; set; }
        }

        public class Handler : IRequestHandler<UniqueAuthor, AuthorDto>
        {
            private readonly ContextAuthor _contextAuthor;
            private readonly IMapper _mapper;

            public Handler(ContextAuthor contextAuthor, IMapper mapper)
            {
                _contextAuthor = contextAuthor;
                _mapper = mapper;
            }

            public async Task<AuthorDto> Handle(UniqueAuthor request, CancellationToken cancellationToken)
            {
                var author = await _contextAuthor.AuthorBook.Where(x => x.AuthorBookGuid == request.AuthorBookGuid).FirstOrDefaultAsync();
                if (author == null) throw new Exception("Author not found");

                var authorDto = _mapper.Map<AuthorBook, AuthorDto>(author);
                return authorDto;
            }
        }

    }
}