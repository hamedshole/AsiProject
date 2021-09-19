using Asi.Application.Interface;
using Asi.Application.Util;
using Asi.Model;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Repositories.Authentication.AddUserSigniture
{
    public class AddUSerSignitureCommandHandler : IRequestHandler<AddUserSignitureCommand>
    {
        private readonly IApplicationBusinessUnit _businessUnit;

        public AddUSerSignitureCommandHandler(IApplicationBusinessUnit businessUnit)
        {
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(AddUserSignitureCommand request, CancellationToken cancellationToken)
        {
            string imagepath = StaticMethods.SaveImage(request.Image, StaticMethods.SavedImageFormat.PNG, StaticMethods.ImageDirectory.Signitures);
            await _businessUnit.Authentication.ChangeUserSigniture(new UserModel { PersonId = request.PersonId, Signiture = request.Image });
            return Unit.Value;
        }
    }
}
