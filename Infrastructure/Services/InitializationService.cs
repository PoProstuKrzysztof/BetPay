using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Services
{
    public class InitializationService : IHostedService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly ILogger<InitializationService> _logger;

        public InitializationService(
            IServiceScopeFactory scopeFactory,
            ILogger<InitializationService> logger)
        {
            _scopeFactory = scopeFactory;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            try
            {
                using var scope = _scopeFactory.CreateScope();
                var syncService = scope.ServiceProvider.GetRequiredService<CountrySynchronizationService>();
                
                _logger.LogInformation("Starting initial data synchronization");
                await syncService.SynchronizeCountriesAsync(cancellationToken);
                _logger.LogInformation("Initial data synchronization completed");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred during initial data synchronization");
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}