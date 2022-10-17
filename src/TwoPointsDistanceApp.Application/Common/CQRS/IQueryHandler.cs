namespace TwoPointsDistanceApp.Application.Common.CQRS;

public interface IQueryHandler<in T, TResult>
{
    ValueTask<TResult> HandleAsync(T query, CancellationToken ct);
}