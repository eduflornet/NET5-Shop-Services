using System;
using System.Threading;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using ShopServices.Api.Author.Model;
using ShopServices.Api.Author.Persistence;

namespace ShopServices.Api.Author.Application
{
    public class Insert
    {
        public class Run : IRequest
        {
            public string Name { get; set; }
            public string LastName { get; set; }
            public DateTime? BirthDate { get; set; }
        }

        public class RunValidation : AbstractValidator<Run>
        {
            public RunValidation()
            {
                // Added validation rules
                RuleFor(x => x.Name).NotEmpty();
                RuleFor(x => x.LastName).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Run>
        {
            public readonly ContextAuthor _contextAuthor;

            public Handler(ContextAuthor contextAuthor)
            {
                _contextAuthor = contextAuthor;
            }

            public async Task<Unit> Handle(Run request, CancellationToken cancellationToken)
            {
                var authorBook = new AuthorBook
                {
                    Name = request.Name,
                    LastName = request.LastName,
                    BirthDate = request.BirthDate,
                    AuthorBookGuid = Convert.ToString(Guid.NewGuid())
                };

                _contextAuthor.AuthorBook.Add(authorBook);
                var value = await _contextAuthor.SaveChangesAsync();
                if (value > 0) return Unit.Value;
                
                throw new Exception("Could not insert the AuthorBook");
            }
        }
    }
}