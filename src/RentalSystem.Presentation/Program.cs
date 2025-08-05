using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RentalSystem.Application;
using RentalSystem.Infra;
using RentalSystem.Infra.DataAccess;
using RentalSystem.Infra.Messaging.Consumers;
using RentalSystem.Presentation.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Rental System API - Gerenciador de aluguel de motos e entregadores.",
        Version = "v1"
    });

    c.TagActionsBy(apiDesc =>
    {
        var controllerAttributes = apiDesc.CustomAttributes().OfType<DisplayNameAttribute>();
        var controllerDisplayName = controllerAttributes.FirstOrDefault()?.DisplayName;

        if (!string.IsNullOrEmpty(controllerDisplayName))
        {
            return new List<string> { controllerDisplayName };
        }

        return new List<string> { apiDesc.ActionDescriptor.RouteValues["controller"] };
    });
});

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

// Hosted services
builder.Services.AddHostedService<MotorcycleRegisteredConsumer>();

builder.Services.AddInfraDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies();

// Comentar pra rodar localmente
builder.WebHost.UseUrls("http://0.0.0.0:5006");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<RentalSystemDbContext>();
    dbContext.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

    app.UseHttpsRedirection();
app.MapControllers();
app.Run();
