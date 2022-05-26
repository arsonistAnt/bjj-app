using Microsoft.Extensions.Configuration;
using BjjAppApi.Models;
using BjjAppApi.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
BjjAppDatabaseSettings bjjAppDatabaseSettings = builder.Configuration.GetSection("BjjAppDatabase").Get<BjjAppDatabaseSettings>();
var mongoClient = new MongoClient(bjjAppDatabaseSettings.ConnectionString);
var mongoDatabase = mongoClient.GetDatabase(bjjAppDatabaseSettings.DatabaseName);
builder.Services.AddSingleton(mongoDatabase.GetCollection<Move>(bjjAppDatabaseSettings.MovesCollectionName));
builder.Services.AddSingleton(mongoDatabase.GetCollection<Demo>(bjjAppDatabaseSettings.DemosCollectionName));
builder.Services.AddSingleton(mongoDatabase.GetCollection<Name>(bjjAppDatabaseSettings.NamesCollectionName));
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
