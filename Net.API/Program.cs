using Microsoft.Extensions.Caching.StackExchangeRedis;

var builder = WebApplication.CreateBuilder(args);

// ==================================================
// Add services to the container.
// ==================================================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var services = builder.Services;

services.AddStackExchangeRedisCache(configRedisCache);

services.AddCors();

services.AddRouting(option => option.LowercaseUrls = true);
// ==================================================
// Configure application
// ==================================================
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(action =>
{
    action.WithHeaders("*");
    action.WithOrigins("*");
    action.AllowAnyHeader();
    action.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

// ==================================================
// Functionality 
// ==================================================

// Config connection for rediscache
void configRedisCache(RedisCacheOptions options)
{

}
