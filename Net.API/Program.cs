using Microsoft.Extensions.Caching.StackExchangeRedis;
using Net.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

// ==================================================
// Add services to the container.
// ==================================================
builder.Services.ConfigureApplicationServices(builder);

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