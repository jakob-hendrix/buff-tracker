using BuffTracker.App;
using BuffTracker.App.Services;
using BuffTracker.App.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSingleton<BuffTrackerViewModel>();
builder.Services.AddSingleton<BuffTrackerState>();
builder.Services.AddSingleton<TimelineEngine>();
builder.Services.AddSingleton<StatusRulesEngine>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();
