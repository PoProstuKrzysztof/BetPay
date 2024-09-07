using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddSyncfusionBlazor();

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzQ2MjcyOEAzMjM2MmUzMDJlMzBtOHNNNERlYmxLZkxiRzlVQWcwV2FHZHNRY2pUMlIreURtY21EMUduVVY4PQ==");

await builder.Build().RunAsync();

public partial class Program
{ }