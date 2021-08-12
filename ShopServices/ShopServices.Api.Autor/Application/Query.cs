using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopServices.Api.Author.Model;
using ShopServices.Api.Author.Persistence;

namespace ShopServices.Api.Author.Application
{
    public class Query
    {
        public class AuthorList : IRequest<List<AuthorDto>> { }

        public class Handler : IRequestHandler<AuthorList, List<AuthorDto>>
        {
            private readonly ContextAuthor _contextAuthor;
            private readonly IMapper _mapper;

            public Handler(ContextAuthor contextAuthor, IMapper mapper)
            {
                _contextAuthor = contextAuthor;
                _mapper = mapper;
            }

            public async Task<List<AuthorDto>> Handle(AuthorList request, CancellationToken cancellationToken)
            {
                var authors = await _contextAuthor.AuthorBook.ToListAsync();
                var authorsDto = _mapper.Map<List<AuthorBook>, List<AuthorDto>>(authors);
                return authorsDto;
            }
        }
    }
}