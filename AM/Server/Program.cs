global using Microsoft.EntityFrameworkCore;
global using AM.Server.Data;
global using AM.Server.Data.DataModel;
global using AutoMapper;
global using AM.Shared.ViewModel;
global using AM.Shared.ViewModel.Pagination;
global using Microsoft.AspNetCore.Components.Authorization;

global using AM.Server.Services.UserService;
global using AM.Server.Services.PublicService;
global using AM.Server.Services.ApartmentService;
global using AM.Server.Services.UnitService;
global using AM.Server.Services.AuthService;
global using AM.Server.Services.NotificationService;

global using AM.Server.Paging;
global using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.ResponseCompression;
using System.Text.Json.Serialization;
using AM.Server;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AM.Client.Services.LoginService;
using AM.Server.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<ApartmentDB>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
});
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);   // time local baraye NPGSQl sabt mishavad. agar nabashad time utc mokafar sabt mikonad

// modiriate Json khoroji be samte client
builder.Services.AddControllers().AddJsonOptions(opt =>
{
    opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    opt.JsonSerializerOptions.WriteIndented = true;
    //opt.JsonSerializerOptions.Converters.Add(new DateTimeConverter("yyyy/MM/dd HH:mm"));

});

//Here we are invoking another service AddDatabaseDeveloperPageExceptionFilter.
//The AddDatabaseDeveloperPageExceptionFilter method helps capture database-related exceptions
//along with possible actions to resolve those in the HTML response format.
//The exceptions can be resolved by using Entity Framework migrations.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddAutoMapper(typeof(Program));
var mapperConfig = new MapperConfiguration(mc => {
    mc.AddProfile(new MapProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IPublicService, PubliceService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IUnitService, UnitService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false,
    };

});

builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapFallbackToFile("index.html");

app.MapHub<NotificationHub>("/notifi");

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApartmentDB>();
    dataContext.Database.Migrate();
}

app.Run();
