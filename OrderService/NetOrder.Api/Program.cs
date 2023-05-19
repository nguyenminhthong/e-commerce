using Net.APICore.Infrastructure.Configuration;
using Net.Core.Configuration;

var builder = WebApplication.CreateBuilder(args);

// ==================================================
// Add services to the container.
// ==================================================
builder.Services.ConfigureApplicationServices(builder.Configuration);
// ==================================================
// Configure application
// ==================================================
var app = builder.Build();

//Configure the application HTTP request pipeline
app.ConfigureRequestPipeline();

// start all app engine if has exist config
app.StartEngine();

// start all services
app.Run();