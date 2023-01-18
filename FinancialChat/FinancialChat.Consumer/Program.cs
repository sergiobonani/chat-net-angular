using FinancialChat.Consumer;
using FinancialChat.Consumer.DTOs;
using FinancialChat.Consumer.Gateways;
using FinancialChat.Consumer.Interfaces;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddSingleton<IChatGateway, ChatGateway>();

        var appSettings = new AppSettings();
        hostContext.Configuration.Bind("AppSettings", appSettings);
        services.AddSingleton(appSettings);
        
        services.AddHostedService<Worker>();        
    })
    .Build();

await host.RunAsync();
