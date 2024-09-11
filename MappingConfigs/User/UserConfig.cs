using Rabis.Api.Dtos.User.Requests;
using TheNevix.AutoMapper.Configurations;
using static TheNevix.AutoMapper.AutoMapper;

namespace Rabis.Api.MappingConfigs.User
{
    public static class UserConfig
    {
        public static void ConfigureCreateUserMapping(this AutoMapperConfiguration config, Mapper mapper)
        {
            config.CreateMap<CreateUserRequest, Domain.User>("CreateUser", (src, dest) =>
            {
                dest.UserName = src.Username;
                dest.Password = src.Password;
                dest.Email = src.Email;
                dest.CreatedOn = DateTimeOffset.UtcNow;
            });
        }

        public static void ConfigureUpdateUserMapping(this AutoMapperConfiguration config, Mapper mapper)
        {
            config.CreateMap<UpdateUserRequest, Domain.User>("UpdateUser", (src, dest) =>
            {
                if (!string.IsNullOrWhiteSpace(src.Username))
                {
                    dest.UserName = src.Username;
                }

                if (!string.IsNullOrWhiteSpace(src.Email))
                {
                    dest.Email = src.Email;
                }

                if (!string.IsNullOrWhiteSpace(src.Password))
                {
                    // Note: Don't forget to hash the password before storing it!
                    dest.Password = src.Password; // Assume HashPassword is a helper method
                }
            });
        }
    }
}
