using ITExpert.DAL.Context;
using ITExpert.Middleware;
using ITExpert.Services;
using ITExpert.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
services.AddControllers();
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// Database
services.AddDbContext<ApplicationDbContext>(option => 
    option.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// Services
services.AddScoped<IDataService, DataService>();
services.AddScoped<IClientService, ClientService>();
services.AddScoped<ILogService, LogService>();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<LogMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();