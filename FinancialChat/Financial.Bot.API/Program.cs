using Financial.Bot.API.DTOs;
using Financial.Bot.API.Infra;
using Financial.Bot.API.Interfaces;
using Financial.Bot.API.UseCases;
using Financial.Bot.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGetInfoGatewayUseCase, GetInfoGatewayUseCase>();
builder.Services.AddScoped<IMessageBroker, MessageBroker>();
builder.Services.AddScoped<IProcessCommandUseCase, ProcessCommandUseCase>();
builder.Services.AddScoped<IGetCommandParameter, GetCommandParameter>();

var appSettings = new AppSettings();
builder.Configuration.Bind("AppSettings", appSettings);
builder.Services.AddSingleton(appSettings);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/processCommand", async (ProcessCommandDto command, IProcessCommandUseCase useCase) =>
{
    await useCase.ExecuteAsync(command);

    return Results.Ok();
})
.WithName("processCommand");

app.Run();