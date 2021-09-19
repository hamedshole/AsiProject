using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Persons.Search
{
    public class SearchPersonCommandHandler : IRequestHandler<SearchPersonCommand, List<PersonModel>>
    {
      
        private readonly IApplicationBusinessUnit _businessUnit;

        public SearchPersonCommandHandler(IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public  async Task<List<PersonModel>> Handle(SearchPersonCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Persons.GetAll();
        }
    }
}
