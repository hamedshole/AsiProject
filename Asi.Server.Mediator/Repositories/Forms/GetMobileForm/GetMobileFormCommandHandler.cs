using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.Forms.GetMobileForm
{
    public class GetMobileFormCommandHandler : IRequestHandler<GetMobileFormCommand, List<FormDataModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;
       
        public GetMobileFormCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
            
        }

        public async Task<List<FormDataModel>> Handle(GetMobileFormCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Form.GetMobileForm(request.FormId);
        }
    }
}
