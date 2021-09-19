using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Provinces.GetAll
{
    public class GetAllProvinceCommand:IRequest<List<ProvinceModel>>
    {
    }
}
