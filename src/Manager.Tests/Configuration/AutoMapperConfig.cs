using AutoMapper;
using Manager.Domain.Entities;
using Manager.Service.DTO;

namespace Manager.Tests.Configuration
{
    public static class AutoMapperConfig
    {
        public static IMapper GetConfiguration()
        {
            var autoMapperConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<User, UserDTO>().ReverseMap();
            });

            return autoMapperConfig.CreateMapper();
        }
    }
}
