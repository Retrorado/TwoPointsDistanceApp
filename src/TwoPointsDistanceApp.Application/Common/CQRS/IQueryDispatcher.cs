namespace TwoPointsDistanceApp.Application.Common.CQRS;

public interface IQueryDispatcher
{
    Task<TQueryResult> ExecuteAsync<TQuery, TQueryResult>(TQuery query);
}