using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.ServiceTypes.Get
{
    public class GetServiceTypeCommand :IRequest<ServiceTypeModel>
    {
        public int Id { get; private set; }

        public GetServiceTypeCommand (int id)
        {
            Id = id;
        }
    }
}
