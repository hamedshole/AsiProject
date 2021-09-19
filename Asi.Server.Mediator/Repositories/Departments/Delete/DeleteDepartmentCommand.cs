using MediatR;

namespace Asi.Server.Mediator.Departments.Delete
{
    public class DeleteDepartmentCommand : IRequest
    {
        public int DepartmentId { get; private set; }

        public DeleteDepartmentCommand(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
