using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SalesAPI.Interfaces;
using SalesAPI.Models;
using SalesAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<ISalesDiscountRepository, SalesDiscountRepository>();
builder.Services.AddTransient<SalesDiscountContext>();
builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
