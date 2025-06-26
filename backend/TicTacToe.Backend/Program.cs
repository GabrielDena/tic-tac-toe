using Microsoft.EntityFrameworkCore;
using Npgsql;
using TicTacToe.Backend.Data;
using TicTacToe.Backend.Repositories;
using TicTacToe.Backend.Repositories.Interfaces;
using TicTacToe.Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IResultsRepository, ResultsRepository>();
builder.Services.AddScoped<ResultsService>();

var dataSourceBuilder = new NpgsqlDataSourceBuilder(Environment.GetEnvironmentVariable("POSTGRES_CONNECTION_STRING"));
var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContextPool<TicTacToeContext>(opt => opt
    .UseNpgsql(dataSource, o => o
        .SetPostgresVersion(13, 0)));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAngularApp");
app.UseHttpsRedirection();


app.MapControllers();

app.Run();