using eCommerce.API.Middlewares;
using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

//Add Infrastructure Services
builder.Services.AddInfrastructureServices();

//Add Core Services
builder.Services.AddCore();

//Add Controllers
builder.Services.AddControllers().AddJsonOptions(
    options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Update the AutoMapper registration to use the correct overload
builder.Services.AddAutoMapper(config =>
{
    config.AddMaps(typeof(ApplicationUserMappingProfile).Assembly);
});

//Fluent Validation
builder.Services.AddFluentValidationAutoValidation();

//API Endpoint --> Swagger
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
//Build App
var app = builder.Build();

//Middleware for Exception Handling
app.UseExceptionHandlingMiddleware();

//Routing
app.UseRouting();
app.UseSwagger();

app.UseSwaggerUI();

app.UseCors();

//Authentication & Authorization
app.UseAuthentication();
app.UseAuthorization();

//Map Controllers
app.MapControllers();
app.Run();
