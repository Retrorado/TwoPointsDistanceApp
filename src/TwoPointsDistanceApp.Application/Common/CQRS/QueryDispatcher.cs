namespace TwoPointsDistanceApp.Application.Common.CQRS;

public class QueryDispatcher : IQueryDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public QueryDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
    }

    public async Task<TQueryResult> ExecuteAsync<TQuery, TQueryResult>(TQuery query)
    {
        if (query is null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var queryHandlerType = typeof(IQueryHandler<TQuery, TQueryResult>);

        if (_serviceProvider.GetService(queryHandlerType) is not IQueryHandler<TQuery, TQueryResult> queryHandler)
        {
            throw new InvalidOperationException(
                $"Cannot find a query handler of type IQueryHandler<{typeof(TQuery).Name}, {typeof(TQueryResult).Name}>");
        }

        return await queryHandler.HandleAsync(query, new CancellationToken());
    }
}