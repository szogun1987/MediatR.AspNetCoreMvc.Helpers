﻿using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MediatR.AspNetCoreMvc.Helpers;

public static class ControllerExtensions
{
    public static async Task<IActionResult> Send<TResponse>(
        this Controller controller,
        IMediator mediator, 
        IRequest<TResponse> request,
        CancellationToken token = default)
    {
        var result = await mediator.Send(request, token);
        if (typeof(TResponse) == typeof(Unit))
        {
            return controller.Ok();
        }
        return controller.Json(result);
    }
    
    public static async Task<IActionResult> Send(
        this Controller controller,
        IMediator mediator, 
        IRequest request,
        CancellationToken token = default)
    {
        await mediator.Send(request, token);
        return controller.Ok();
    }
}