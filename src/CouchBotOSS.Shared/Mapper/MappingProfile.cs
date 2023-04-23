using AutoMapper;
using CouchBotOSS.Data.Models;
using CouchBotOSS.Shared.Dtos;

namespace CouchBotOSS.Shared.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DiscordUser, DiscordUserDto>().ReverseMap();
        }
    }
}
