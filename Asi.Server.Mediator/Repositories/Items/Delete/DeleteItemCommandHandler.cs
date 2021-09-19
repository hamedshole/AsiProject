using Asi.Application.Interface;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Asi.Server.Mediator.Items.Delete
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public DeleteItemCommandHandler( IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
           await _businessUnit.Items.Delete(request.Id);
            return Unit.Value;
        }
    }
}
