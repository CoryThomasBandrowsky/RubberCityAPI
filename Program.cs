using Domain.Models;
using Microsoft.Extensions.Configuration;
using RubberCity.Data.Interfaces;
using RubberCity.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var allowOrigins = "_allowOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: allowOrigins,
                      builder =>
                      {
                          var corsOrigins = configuration.GetSection("CorsOrigins").Get<string[]>();
                          builder.WithOrigins(corsOrigins)
                                 .AllowAnyHeader()
                                 .AllowAnyMethod();
                      });
});

var connectionString = configuration.GetConnectionString("RubberCityMaster");
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("Values"));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IRepository<User>, UserRepository>(sp =>
    new UserRepository(builder.Configuration.GetConnectionString("RubberCityMaster")));

var app = builder.Build();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors(allowOrigins);
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.Run();
