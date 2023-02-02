using GpaCalculator.Api;
using GpaCalculator.Api.Db;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(c =>c.UseSqlServer(builder.Configuration["AppDbContextConnection"]), ServiceLifetime.Scoped); 
builder.Services.AddTransient<IGPAService, GPAService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetService<AppDbContext>();

dbContext!.Database.EnsureCreated();

app.MapControllers();

app.Run();