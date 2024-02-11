using Dapper;
using DbWebApplicationTemplate.Infrastructure;
using MediatR;

namespace DbWebApplicationTemplate.DataAccess.Handlers.V1;

using static TestCreate;

public class TestCreateHandler : IRequestHandler<Request, Response>
{
    
    private const string Query = @$"
        INSERT INTO {PgTables.Record} (data) VALUES (@Data)
        RETURNING id";
    
    private readonly IDbContext _dbContext;

    public TestCreateHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        await using var dbConnection = _dbContext.GetConnection();
        await dbConnection.OpenAsync(cancellationToken);
        
        return await dbConnection.QuerySingleAsync<Response>(Query, new {request.Data});
    }
}