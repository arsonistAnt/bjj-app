using BjjAppApi.Interfaces;
using BjjAppApi.Models;
using BjjAppApi.Repositories;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
BjjAppDatabaseSettings bjjAppDatabaseSettings = builder.Configuration.GetSection("BjjAppDatabase").Get<BjjAppDatabaseSettings>();
var mongoClient = new MongoClient(bjjAppDatabaseSettings.ConnectionString);
var mongoDatabase = mongoClient.GetDatabase(bjjAppDatabaseSettings.DatabaseName);
builder.Services.AddSingleton(mongoDatabase.GetCollection<Move>(bjjAppDatabaseSettings.MovesCollectionName));
builder.Services.AddSingleton(mongoDatabase.GetCollection<Demo>(bjjAppDatabaseSettings.DemosCollectionName));
builder.Services.AddSingleton(mongoDatabase.GetCollection<Name>(bjjAppDatabaseSettings.NamesCollectionName));
builder.Services.AddSingleton<IMovesRepository, MovesMongoRepository>();
builder.Services.AddSingleton<IDemosRepository, DemosMongoRepository>();
builder.Services.AddSingleton<INamesRepository, NamesMongoRepository>();

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
