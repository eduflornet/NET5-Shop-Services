using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ShopService.Api.Book.Model;
using ShopService.Api.Book.Persistence;

namespace ShopService.Api.Book.Application
{
    public class Insert
    {
        public class Run : IRequest
        {
            public string Title { get; set; }
            public DateTime PublicationDate { get; set; }
            public Guid? AuthorBookGuid { get; set; }
        }

        public class RunValidation : AbstractValidator<Run>
        {
            public RunValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.PublicationDate).NotEmpty();
                RuleFor(x => x.AuthorBookGuid).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Run>
        {
            private readonly ContextLibrary _contextLibrary;

            public Handler(ContextLibrary contextLibrary)
            {
                _contextLibrary = contextLibrary;
            }

            public async Task<Unit> Handle(Run request, CancellationToken cancellationToken)
            {
                var book = new LibraryMaterial
                {
                    Title = request.Title,
                    PublicationDate = request.PublicationDate,
                    AuthorBookGuid = request.AuthorBookGuid
                };

                _contextLibrary.Add(book);
                var value = await _contextLibrary.SaveChangesAsync();
                if (value > 0) return Unit.Value;
                
                throw new Exception("Could not save the Book");
            }
        }

    }
}
