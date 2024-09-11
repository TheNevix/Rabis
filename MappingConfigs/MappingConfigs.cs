using static TheNevix.AutoMapper.AutoMapper;
using TheNevix.AutoMapper.Configurations;
using Rabis.Api.MappingConfigs.User;

namespace Rabis.Api.MappingConfigs
{
    public static class MappingConfigs
    {
        public static Mapper ConfigureMappings()
        {
            var config = new AutoMapperConfiguration();
            var mapper = new Mapper(config);

            config.ConfigureCreateUserMapping(mapper);
            config.ConfigureUpdateUserMapping(mapper);

            return mapper;
        }
    }
}
