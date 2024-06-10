using Application;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService();

builder.Services.AddSingleton<IConnectionMultiplexer>(ConnectionMultiplexer.Connect(builder.Configuration["CacheConnection"] ?? string.Empty));
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseCosmos(
    builder.Configuration["CosmosEndpoint"] ?? string.Empty,
    builder.Configuration["CosmosAccountKey"] ?? string.Empty,
    builder.Configuration["CosmosDbName"] ?? string.Empty
));
builder.Services.AddHttpClient();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
