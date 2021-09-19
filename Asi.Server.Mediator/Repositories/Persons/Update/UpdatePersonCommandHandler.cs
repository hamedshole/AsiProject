using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Persons.Update
{
    public class UpdatePersonCommandHandler : IRequestHandler<UpdatePersonCommand>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public UpdatePersonCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(UpdatePersonCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Persons.Update(request);
            return Unit.Value;
        }
    }
}
