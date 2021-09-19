using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Items.Update
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand>
    {

        private readonly IApplicationBusinessUnit _businessUnit;

        public UpdateItemCommandHandler(IApplicationBusinessUnit businessUnit)
        {

            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            await _businessUnit.Items.Update(request);
            return Unit.Value;
        }
    }
}
