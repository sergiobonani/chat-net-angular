using FinancialChat.Domain.Dtos;
using FinancialChat.Infra.IoC;
using FinancialChat.Web.Hubs;
using FinancialChat.Web.Interfaces;

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

var appSettings = new AppSettings();
builder.Configuration.Bind("AppSettings", appSettings);
builder.Services.AddSingleton(appSettings);

//builder.Services.Configure<AppSettings>(builder.Configuration);
//builder.Services.AddScoped(c => c.GetService<IOptionsSnapshot<AppSettings>>().Value);

NativeInjector.RegisterServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseCors("CorsPolicy");
app.UseRouting();

app.UseAuthorization();

//app.MapRazorPages();
//app.MapHub<ChatHub>("/chatHub");

app.MapPost("/sendmessage", async (MessageRequestDto command, IChatHub chatHub) =>
{
    await chatHub.OnNewMessageAsync(command.User.Name, command.Message);

    return Results.Ok();
})
.WithName("sendmessage");

app.Run();
