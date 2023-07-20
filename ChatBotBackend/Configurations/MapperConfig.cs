using AutoMapper;
using ChatBotBackend.Data;

namespace ChatBotBackend.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {

            CreateMap<User, RespnseDto>().ReverseMap();
        }
    }
}
