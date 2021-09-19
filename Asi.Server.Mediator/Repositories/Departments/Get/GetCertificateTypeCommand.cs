using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Departments.Get
{
    public class GetDepartmentCommand:IRequest<DepartmentModel>
    {
        public int Id { get; private set; }

        public GetDepartmentCommand(int title)
        {
            Id = title;
        }
    }
}
