using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Api.Helper.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseAppSettingsEnvironment(); //Custom
builder.Host.UseSerilog((context, loggerConfig) => {
    loggerConfig.ReadFrom.Configuration(context.Configuration);
});

builder.Services.AddIdentityDbContext(builder.Configuration); //Custom
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddStackExchangeRedisCache(redisOptions => {
    redisOptions.Configuration = builder.Configuration.GetConnectionString("Redis");
});


var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseSerilogRequestLogging();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
