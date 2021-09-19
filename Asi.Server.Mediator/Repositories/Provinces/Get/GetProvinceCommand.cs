using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Provinces.Get
{
    public class GetProvinceCommand:IRequest<ProvinceModel>
    {
        public int Id { get; private set; }

        public GetProvinceCommand(int id)
        {
            Id = id;
        }
    }
}
