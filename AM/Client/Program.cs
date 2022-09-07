global using AM.Shared.ViewModel;
global using Blazored.Toast.Services;
global using Blazored.LocalStorage;
global using AM.Client.Services;
global using AM.Shared.ViewModel.Pagination;
global using Microsoft.AspNetCore.Components.Authorization;
global using  Microsoft.AspNetCore.SignalR.Client;

using AM.Client.Services.UserService;
using AM.Client.Services.ApartmentService;
using AM.Client.Services.UnitService;
using AM.Client.Services.LoginService;
using AM.Client.Services.NotificationService;

using AM.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Blazored.Toast;
using MudBlazor.Services;
using Append.Blazor.Notifications;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IUserHttpService, UserHttpService>();
builder.Services.AddScoped<IApartmentHttpService, ApartmentHttpService>();
builder.Services.AddScoped<IUnitHttpService, UnitHttpService>();
builder.Services.AddScoped<ILoginHttpService, LoginHttpService>();
builder.Services.AddScoped<INotificationHttpService, NotificationHttpService>();


builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();

builder.Services.AddBlazoredToast();
builder.Services.AddMudServices();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddNotifications();

await builder.Build().RunAsync();
