using AutoMapper;
using FinancialChat.Application.ViewModels;
using FinancialChat.Domain.Dtos;

namespace FinancialChat.Application.AutoMapper
{
    public class MessageToCommandMappingProfile : Profile
    {
        public MessageToCommandMappingProfile()
        {
            CreateMap<MessageViewModel, BotCommandRequestDto>()
                .ForMember(x => x.SenderId, z => z.MapFrom(y => y.User.Id))
                .ForMember(x => x.Message, z => z.MapFrom(y => y.Content));
        }
    }
}
