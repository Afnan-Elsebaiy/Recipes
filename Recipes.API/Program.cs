
using Recipes.API.ExceptionHandling;
using Recipes.Application.Mappings;
using Recipes.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();



builder.Services.AddOpenApi();

builder.Services.AddApplicationServices();

builder.Services.AddInfrastructureServices(
    builder.Configuration);

builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();