using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.AspNetCoreMvc.Helpers
{
    public class MediatRController : Controller
    {
        private readonly IMediator _mediator;

        public MediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<IActionResult> Send<TRequest>(TRequest request, CancellationToken token = default(CancellationToken)) where TRequest : IRequest
        {
            return _mediator.Send<TRequest>(request, token);
        }

        public Task<IActionResult> Send<TRequest, TResult>(
            TRequest request,
            CancellationToken token = default(CancellationToken)) where TRequest : IRequest<TResult>
        {
            return _mediator.Send<TRequest, TResult>(request, token);
        }
    }
}