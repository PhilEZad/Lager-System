using Infrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database file
builder.Services.AddDbContext<DatabaseContext>(options =>
{
    options.UseSqlite(
        "Data Source=db.db"
    );
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

// Registering layers
Application.DependencyResolver.DependencyResolver.RegisterApplicationLayer(builder.Services);
Infrastructure.DependencyResolver.DependencyResolver.RegisterInfrastructureLayer(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();