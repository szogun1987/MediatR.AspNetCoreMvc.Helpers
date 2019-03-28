# MediatR.AspNetCoreMvc.Helpers
A super simple set of extensions, easing integration of MediatR library with ASP.Net MVC Core.

## MediatRController
Extends standard Controller with Send method accepting your request and optional cancellation token.
```
public class IndexController : MediatRController
{
    public IndexController(IMediator mediator)
    : base(mediator)
    {

    }

    [HttpGet]
    public Task<IActionResult> Get(CancellationToken token) => Send(new GetAllRequest(), token);
}
```

## Extension method 
Use it if you don't like or cannot inherit.
```
public class IndexController : Controller
{
    private readonly IMediator _mediator;

    public IndexController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public Task<IActionResult> Get(CancellationToken token) => this.Send(_mediator, new GetAllRequest(), token);
}
```
