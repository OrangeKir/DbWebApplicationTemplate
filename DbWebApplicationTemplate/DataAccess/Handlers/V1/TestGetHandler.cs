using Dapper;
using DbWebApplicationTemplate.Infrastructure;
using MediatR;

namespace DbWebApplicationTemplate.DataAccess.Handlers.V1;

using static TestGet;

public class TestGetHandler : IRequestHandler<Request, Response>
{
    private const string Query = @$"
        SELECT
            data
        FROM {PgTables.Record}
        WHERE id = @Id";
    
    private readonly IDbContext _dbContext;

    public TestGetHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        await using var dbConnection = _dbContext.GetConnection();
        await dbConnection.OpenAsync(cancellationToken);
        
        return await dbConnection.QuerySingleAsync<Response>(Query, new {request.Id});
    }
}