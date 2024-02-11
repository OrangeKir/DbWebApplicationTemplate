using MediatR;

namespace DbWebApplicationTemplate.DataAccess.Handlers.V1;

public class TestGet
{
    public record Request(Guid Id) : IRequest<Response>;

    public record Response(string Data);
}