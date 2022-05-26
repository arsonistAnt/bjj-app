using Microsoft.Extensions.Configuration;
using BjjAppApi.Models;
using BjjAppApi.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
BjjAppDatabaseSettings bjjAppDatabaseSettings = builder.Configuration.GetSection("BjjAppDatabase").Get<BjjAppDatabaseSettings>();
var mongoClient = new MongoClient(bjjAppDatabaseSettings.ConnectionString);
var mongoDatabase = mongoClient.GetDatabase(bjjAppDatabaseSettings.DatabaseName);
var movesCollection = mongoDatabase.GetCollection<Move>(bjjAppDatabaseSettings.MovesCollectionName);
var demosCollection = mongoDatabase.GetCollection<Demo>(bjjAppDatabaseSettings.DemosCollectionName);
var namesCollection = mongoDatabase.GetCollection<Name>(bjjAppDatabaseSettings.NamesCollectionName);
builder.Services.AddSingleton(movesCollection);
builder.Services.AddSingleton(demosCollection);
builder.Services.AddSingleton(namesCollection);
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
