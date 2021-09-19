using Asi.Application.Interface;
using Asi.Domain.Common;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Persons.GetAllPaged
{
    public class GetAllPagedPersonCommandHandler : IRequestHandler<GetAllPagedPersonCommand, PagedList<PersonModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public GetAllPagedPersonCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<PagedList<PersonModel>> Handle(GetAllPagedPersonCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Persons.GetAll(request.PageNumber, request.PageSize);
        }
    }
}
