using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Application.Mediator.Repositories.Forms.GetMobileForm
{
    public class GetMobileFormCommand:IRequest<List<FormDataModel>>
    {
        public int FormId { get; private set; }

        public GetMobileFormCommand(int formId)
        {
            FormId = formId;
        }
    }
}
