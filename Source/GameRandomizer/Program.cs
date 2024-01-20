using GameRandomizer.Interfaces;
using GameRandomizer.Middleware;
using GameRandomizer.Services;
using GiantBomb.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IGiantBombService, GiantBombService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseMiddleware<ApiKeyMiddleware>();
app.UseHttpsRedirection();

app.Run();