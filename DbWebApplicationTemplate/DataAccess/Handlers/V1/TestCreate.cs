using MediatR;

namespace DbWebApplicationTemplate.DataAccess.Handlers.V1;

public class TestCreate
{
    public record Request(string Data) : IRequest<Response>;

    public record Response(Guid Id);
}