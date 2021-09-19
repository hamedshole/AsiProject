using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Persons.Get
{
    public class GetPersonCommandHandler : IRequestHandler<GetPersonCommand, PersonModel>
    {
      
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetPersonCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<PersonModel> Handle(GetPersonCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Persons.Get(request.Id);
        }
    }
}
