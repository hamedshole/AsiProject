using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.ServiceTypes.GetAll
{
    public class GetAllServiceTypeCommand :IRequest<List<ServiceTypeModel>>
    {
    }
}
