using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyBudgetAppAPI.Data;
using MyBudgetAppAPI.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{
    Options.UseNpgsql(builder.Configuration.GetConnectionString("MyBudget"));
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//builder.Services.AddSingleton<TransactionRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

//Routing
//Reading all ransactions
// app.MapGet("/transactions", () =>
// {
//     return "Reading all transactions";
// });

// //Get a transaction by id
// app.MapGet("/transactions/{id}", (int id) =>
// {
//     return $"Reading transaction with id:{id}";
// });
// //Creating a transaction
// app.MapPost("/transactions", () =>
// {
//     return "Creating a transaction";
// });

app.Run();
