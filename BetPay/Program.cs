using Application;
using BetPay.Components;
using Domain.Contracts;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSyncfusionBlazor();
builder.Services.AddRazorComponents();
builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

builder.Services.AddDbContextPool<RepositoryContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
        sqlServerOptionsAction: sqlOptions =>
        {
            sqlOptions.EnableRetryOnFailure();
            sqlOptions.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
        });
    options.UseLazyLoadingProxies();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ0NzY1NEAzMjM2MmUzMDJlMzBBRGN6bnVwUXo1TGY4WjBVY21LSWV2MWlCTVFXS0lBRk9mY2trSEZlNGk4PQ== ");

app.MapRazorComponents<App>();

 app.Run();

public partial class Program
{ }