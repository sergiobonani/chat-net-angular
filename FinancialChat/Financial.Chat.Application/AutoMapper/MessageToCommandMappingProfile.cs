using AutoMapper;

namespace Financial.Chat.Application.AutoMapper
{
    public class MessageToCommandMappingProfile : Profile
    {
        public MessageToCommandMappingProfile()
        {
            //CreateMap<MessageRequestDto, BotCommandRequestDto>()
            //    .ForMember(x => x.SenderId, z => z.MapFrom(y => y.User.Id))
            //    .ForMember(x => x.Message, z => z.MapFrom(y => y.Message));
        }
    }
}
