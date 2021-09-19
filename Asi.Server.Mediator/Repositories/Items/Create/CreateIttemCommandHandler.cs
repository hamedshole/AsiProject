using Asi.Application.Interface;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
namespace Asi.Server.Mediator.Items.Create
{
    public class CreateIttemCommandHandler : IRequestHandler<CreateItemCommand>
    {
       
        private readonly IApplicationBusinessUnit _businessUnit;

        public CreateIttemCommandHandler( IApplicationBusinessUnit businessUnit)
        {
           
            _businessUnit = businessUnit;
        }

        public async Task<Unit> Handle(CreateItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
               await _businessUnit.Items.Create(request);
             

                return Unit.Value;
            }
            catch (Exception e)
            {

                throw;
            }
           

        }

       
    }
}
