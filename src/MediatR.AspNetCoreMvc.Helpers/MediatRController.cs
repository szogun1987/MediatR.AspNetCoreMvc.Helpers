using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.AspNetCoreMvc.Helpers;

public class MediatRController : Controller
{
    private readonly IMediator _mediator;

    public MediatRController(IMediator mediator)
    {
        _mediator = mediator;
    }
        
    public Task<IActionResult> Send<TResponse>(
        IRequest<TResponse> request,
        CancellationToken token = default)
    {
        return this.Send(_mediator, request, token);
    }
}