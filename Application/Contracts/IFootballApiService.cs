public interface IFootballApiService
{
    Task<T?> GetAsync<T>(string endpoint, CancellationToken cancellationToken = default) where T : class;
} 