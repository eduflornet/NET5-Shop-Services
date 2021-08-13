using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ShopService.Api.Book.Model;
using ShopService.Api.Book.Persistence;

namespace ShopService.Api.Book.Application
{
    public class Query
    {
        public class BookList : IRequest<List<BookDto>> { }

        public class Handler : IRequestHandler<BookList, List<BookDto>>
        {
            private readonly ContextLibrary _contextLibrary;
            private readonly IMapper _mapper;
            public Handler(ContextLibrary contextLibrary, IMapper mapper)
            {
                _contextLibrary = contextLibrary;
                _mapper = mapper;
            }

            public async Task<List<BookDto>> Handle(BookList request, CancellationToken cancellationToken)
            {
                var books = await _contextLibrary.LibraryMaterial.ToListAsync();
                var booksDtos = _mapper.Map<List<LibraryMaterial>, List<BookDto>>(books);
                return booksDtos;
            }
        }

    }
}
