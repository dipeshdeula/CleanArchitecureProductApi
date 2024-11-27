using CleanArchitecureProductApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Win32;
using ProductApi.Domain.Interfaces;
using ProductApi.Infrastructure.Repositories;

using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register the connection string
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register the repository
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddApiDi(builder.Configuration);

//Add CORS services and configure policies
builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AllowAllOrigins",
        policy =>
        {
            policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
        });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

//Use CORS with the defined policy
app.UseCors("AllowAllOrigins");

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

app.Run();
