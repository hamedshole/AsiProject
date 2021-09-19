using Asi.Model;
using MediatR;
using System.Collections.Generic;

namespace Asi.Server.Mediator.Departments.GetAll
{
    public class GetAllDepartmentCommand:IRequest<List<DepartmentModel>>
    {
    }
}
