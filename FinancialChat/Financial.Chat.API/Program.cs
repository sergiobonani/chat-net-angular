using Financial.Chat.API.Hubs;
using Financial.Chat.Domain.Dtos;
using Financial.Chat.Infra.IoC;
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

const string CorsPolicy = "CorsPolicy";

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(CorsPolicy,
        builder =>
        {
            builder.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:4200")
            .AllowCredentials();
        });
});
builder.Services.AddSignalR();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var appSettings = new AppSettings();
builder.Configuration.Bind("AppSettings", appSettings);
builder.Services.AddSingleton(appSettings);

NativeInjector.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(CorsPolicy);

app.MapHub<ChatHub>("/chatHub");

app.MapPost("/sendmessage", async (MessageRequestDto command, IHubContext<ChatHub> chatHub) =>
{
    await chatHub.Clients.Group(appSettings.ChatSettings.GroupName).SendAsync("OnNewMessageAsync", command.SenderName, command.Message);

    return Results.Ok();
})
.WithName("sendmessage");

app.Run();
