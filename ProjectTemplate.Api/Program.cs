using ProjectTemplate.Api.Helper.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.AppSettingsEnvironmentSetup();
builder.Host.UseSerilog((context, loggerConfig) => {
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(redisOptions => {
    redisOptions.Configuration = builder.Configuration.GetConnectionString("Redis");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseAuthorization();

app.MapControllers();

app.Run();
