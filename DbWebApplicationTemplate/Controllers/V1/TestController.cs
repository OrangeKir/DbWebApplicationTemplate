using DbWebApplicationTemplate.DataAccess.Handlers.V1;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DbWebApplicationTemplate.Controllers.V1;

[ApiController]
[Route("v1")]
public class TestController : ControllerBase
{
    private readonly IMediator _mediator;

    public TestController(IMediator mediator)
        => _mediator = mediator;

    [HttpGet("{id}/test-get")]
    public Task<TestGet.Response> TestGetAsync(Guid id)
        => _mediator.Send(new TestGet.Request(id));

    [HttpPut("test-put")]
    public Task<TestCreate.Response> TestCreateAsync(TestCreate.Request request)
        => _mediator.Send(request);
}