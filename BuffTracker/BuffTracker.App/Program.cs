using Blazored.LocalStorage;
using BuffTracker.App;
using BuffTracker.Shared.Services;
using BuffTracker.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

#region Services

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddMudServices();

builder.Services.AddSingleton<BuffTrackerViewModel>();
builder.Services.AddSingleton<AppState>();
builder.Services.AddSingleton<TimelineViewModel>();
builder.Services.AddSingleton<StatusRulesEngine>();
builder.Services.AddBlazoredLocalStorageAsSingleton();


#endregion

await builder.Build().RunAsync();
