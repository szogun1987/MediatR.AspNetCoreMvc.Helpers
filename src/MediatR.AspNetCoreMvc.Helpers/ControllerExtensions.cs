using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.AspNetCoreMvc.Helpers
{
    public static class ControllerExtensions
    {
        public static async Task<IActionResult> Send<TRequest>(this IMediator mediator, TRequest request, CancellationToken token = default(CancellationToken)) where TRequest : IRequest
        {
            await mediator.Send(request, token);
            return new OkResult();
        }

        public static async Task<IActionResult> Send<TRequest, TResult>(
            this IMediator mediator, 
            TRequest request,
            CancellationToken token = default(CancellationToken)) where TRequest : IRequest<TResult>
        {
            var result = await mediator.Send(request, token);
            return new OkObjectResult(result);
        }
    }
}
