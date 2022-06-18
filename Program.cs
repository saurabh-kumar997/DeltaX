using System.Text.Json.Serialization;
using AutoMapper;
using Deltax.Entities;
using Deltax.Helpers.AutoMap;
using Deltax.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Sql Connection
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DeltaDBContext>(x => x.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Configuring automapper
var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperClass());
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

//DI injection
builder.Services.AddScoped<IMasterServices, MasterServices>();
builder.Services.AddScoped<IMovieServices, MovieServices>();
builder.Services.AddScoped<IActorServices, ActorServices>();
builder.Services.AddScoped<IProducerServices, ProducerServices>();

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
