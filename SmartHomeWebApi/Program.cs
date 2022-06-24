using Microsoft.EntityFrameworkCore;
using SmartHomeWebApi.Data;
using SmartHomeWebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer("Server=db;Database=SmartHome;User Id=sa;Password=Tackshine1209");
});
builder.Services.AddDbFactory();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.UseCors(options =>
{
    options.AllowAnyHeader();
    options.AllowAnyOrigin();
    options.AllowAnyMethod();
    
});

app.Run();