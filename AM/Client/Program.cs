global using AM.Shared.ViewModel;
global using Blazored.Toast.Services;
global using Blazored.LocalStorage;
global using AM.Client.Services;

using AM.Client.Services.UserService;
using AM.Client.Services.ApartmentService;

using AM.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Toast;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IUserHttpService, UserHttpService>();
builder.Services.AddScoped<IApartmentHttpService, ApartmentHttpService>();

builder.Services.AddBlazoredToast();
builder.Services.AddMudServices();

builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
