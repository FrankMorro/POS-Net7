using POS.Application.Extensions;
using POS.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

// Add services to the container.
var Cors = "Cors";

// Agregamos la Injection de la configuracion de nuestro dbcontext
builder.Services.AddInjectionInfrastructure(Configuration);
builder.Services.AddInjectionApplication(Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Habilitamos Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: Cors, policy =>
    {
        policy.WithOrigins("*");
        policy.WithMethods("PUT", "DELETE", "GET");
        policy.AllowAnyHeader();
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

app.UseCors(Cors);

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }