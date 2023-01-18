using Financial.Chat.Application.AutoMapper;
using Financial.Chat.Application.Interfaces.UseCases;
using Financial.Chat.Application.Services;
using Financial.Chat.Domain.Interfaces;
using Financial.Chat.Infra.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace Financial.Chat.Infra.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //USECASES
            services.AddScoped<ISendCommandToBotUseCase, SendCommandToBotUseCase>();

            //GATEWAYS
            services.AddScoped<IBotGateway, BotGateway>();

            //MAPPER
            var config = AutoMapperConfig.RegisterMappings();
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}