using RentalSystem.Application;
using RentalSystem.Infra;
using RentalSystem.Infra.Messaging.Consumers;
using RentalSystem.Presentation.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
    .AddEnvironmentVariables();



builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

// hosted services
builder.Services.AddHostedService<MotorcycleRegisteredConsumer>();

builder.Services.AddInfraDependencies(builder.Configuration);
builder.Services.AddApplicationDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
