using BetPay.Components;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Jedna rejestracja DbContext
builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
            sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        });
    options.UseLazyLoadingProxies();
    options.EnableDetailedErrors();
    options.EnableSensitiveDataLogging();
}, ServiceLifetime.Scoped);

// Dodaj inne serwisy
builder.Services.AddInfrastructure(builder.Configuration);

// Konfiguracja Blazor
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSyncfusionBlazor();
builder.Services.AddControllers();
builder.Services.AddAntiforgery();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    try
    {
        var syncService = scope.ServiceProvider.GetRequiredService<CountrySynchronizationService>();
        await syncService.SynchronizeCountriesAsync();
        app.Logger.LogInformation("Successfully synchronized countries at startup");
    }
    catch (Exception ex)
    {
        app.Logger.LogError(ex, "An error occurred while synchronizing countries at startup");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(builder.Configuration["Syncfusion:LicenseKey"]);
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode();

app.Run();

public partial class Program
{ }