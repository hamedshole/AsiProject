using Asi.Application.Interface;
using Asi.Model;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Application.Mediator.Repositories.Forms.GetItemForm
{
    public class GetItemFormCommandHandler : IRequestHandler<GetItemFormCommand, List<FormTemplateModel>>
    {
        private readonly IApplicationBusinessUnit _businessUnit;
       

        public GetItemFormCommandHandler(IApplicationBusinessUnit businessUnit)
        {
          
            _businessUnit = businessUnit;
        }

        public  async Task<List<FormTemplateModel>> Handle(GetItemFormCommand request, CancellationToken cancellationToken)
        {
            return await _businessUnit.Form.GetItemForms(request.ItemId);
        }
    }
}
