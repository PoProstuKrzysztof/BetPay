using Infrastructure.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Middleware
{
    public class DataInitializationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly CountrySynchronizationService _syncService;
        private readonly ILogger<DataInitializationMiddleware> _logger;
        private static bool _isInitialized;
        private static readonly object _lock = new();

        public DataInitializationMiddleware(
            RequestDelegate next,
            CountrySynchronizationService syncService,
            ILogger<DataInitializationMiddleware> logger)
        {
            _next = next;
            _syncService = syncService;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!_isInitialized)
            {
                lock (_lock)
                {
                    if (!_isInitialized)
                    {
                        try
                        {
                            _logger.LogInformation("Starting initial data synchronization");
                            _syncService.SynchronizeCountriesAsync(context.RequestAborted).Wait();
                            _isInitialized = true;
                            _logger.LogInformation("Initial data synchronization completed");
                        }
                        catch (Exception ex)
                        {
                            _logger.LogError(ex, "Error during initial data synchronization");
                        }
                    }
                }
            }

            await _next(context);
        }
    }
}