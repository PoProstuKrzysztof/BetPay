using Application.Contracts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Infrastructure.Services.Endpoints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        services.Configure<FootballApiOptions>(
            configuration.GetSection(FootballApiOptions.SectionName));

        services.AddHttpClient();
        services.AddScoped<IFootballApiService, FootballApiService>();

        services.AddScoped<ICountryEndpoint, CountryEndpoint>();
        services.AddScoped<ILeagueEndpoint, LeagueEndpoint>();

        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<ILeagueTournamentRepository, LeagueTournamentRepository>();
        services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

        services.AddScoped<CountrySynchronizationService>();
        services.AddScoped<LeagueSynchronizationService>();

        services.AddHostedService<InitializationService>();

        return services;
    }
}