using BjjAppApi.Models;
using BjjAppApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<BjjAppDatabaseSettings>(
    builder.Configuration.GetSection("BjjAppDatabase"));

builder.Services.AddSingleton<MovesService>();
builder.Services.AddSingleton<DemosService>();
builder.Services.AddSingleton<NamesService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
