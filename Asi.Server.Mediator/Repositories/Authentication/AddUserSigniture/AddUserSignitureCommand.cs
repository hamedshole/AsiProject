using MediatR;

namespace Asi.Server.Mediator.Repositories.Authentication.AddUserSigniture
{
    public class AddUserSignitureCommand : IRequest
    {
        public int PersonId { get; private set; }
        public string Image { get; private set; }

        public AddUserSignitureCommand(int personId, string image)
        {
            PersonId = personId;
            Image = image;
        }
    }
}
