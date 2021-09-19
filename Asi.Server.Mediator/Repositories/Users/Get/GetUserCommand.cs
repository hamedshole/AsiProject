using Asi.Model;
using MediatR;

namespace Asi.Server.Mediator.Users.Get
{
    public class GetUserCommand :IRequest<UserModel>
    {
        public int Id { get; private set; }

        public GetUserCommand (int id)
        {
            Id = id;
        }
    }
}
