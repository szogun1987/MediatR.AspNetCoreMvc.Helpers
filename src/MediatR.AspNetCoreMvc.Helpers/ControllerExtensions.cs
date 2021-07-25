using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.AspNetCoreMvc.Helpers
{
    public static class ControllerExtensions
    {
        public static async Task<IActionResult> Send<TResponse>(
            this Controller controller,
            IMediator mediator, 
            IRequest<TResponse> request,
            CancellationToken token = default(CancellationToken))
        {
            var result = await mediator.Send(request, token);
            if (typeof(TResponse) == typeof(Unit))
            {
                return controller.Ok();
            }
            return controller.Json(result);
        }
    }
}
