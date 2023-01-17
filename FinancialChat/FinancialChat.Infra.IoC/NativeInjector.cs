using FinancialChat.Application.AutoMapper;
using FinancialChat.Application.Interfaces.UseCases;
using FinancialChat.Application.Services;
using FinancialChat.Domain.Interfaces;
using FinancialChat.Infra.Gateways;
using Microsoft.Extensions.DependencyInjection;

namespace FinancialChat.Infra.IoC
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