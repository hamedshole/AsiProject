using MediatR;

namespace Asi.Server.Mediator.Provinces.Delete
{
    public class DeleteProvinceCommand : IRequest
    {
        public int Id { get; private set; }

        public DeleteProvinceCommand(int id)
        {
            this.Id = id;
        }
    }
}
