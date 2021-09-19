using Asi.Application.Interface;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Persons.Create
{
    public class CreatePersonCommandHandler : IRequestHandler<CreatePersonCommand>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreatePersonCommandHandler(IMapper mapper, IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreatePersonCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Persons.Create(request);
            return Unit.Value;
        }
    }
}
