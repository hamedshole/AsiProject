using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Persons.GetAll
{
    public class GetAllPersonCommandHandler : IRequestHandler<GetAllPersonCommand, List<PersonModel>>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPersonCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            
            _businessUnit = businessUnit;
        }

        public  async Task<List<PersonModel>> Handle(GetAllPersonCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Persons.GetAll();
        }
    }
}
