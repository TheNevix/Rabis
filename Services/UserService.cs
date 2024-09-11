using Microsoft.EntityFrameworkCore;
using Rabis.Api.Core;
using Rabis.Api.Domain;
using Rabis.Api.Dtos.User.Requests;
using Rabis.Api.Dtos.User.Responses;
using Rabis.Api.Models;
using static TheNevix.AutoMapper.AutoMapper;

namespace Rabis.Api.Services
{
    public class UserService
    {
        private readonly RabisDbContext _dbContext;
        private readonly Mapper _mapper;

        public UserService(RabisDbContext dbContext, Mapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ServiceResult> Create(CreateUserRequest request)
        {
            //Check if email already exists
            var users = await _dbContext.Users.ToListAsync();

            if (users.Any(u => u.Email == request.Email)) 
            {
                return new ServiceResult
                {
                    Messages = new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "EmailExists",
                            Message = "The provided email already exists.",
                            MessagePriority = MessagePriority.Error
                        }
                    }
                };
            }

            if (users.Any(u => u.UserName == request.Email))
            {
                return new ServiceResult
                {
                    Messages = new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "UsernameExists",
                            Message = "The provided username already exists.",
                            MessagePriority = MessagePriority.Error
                        }
                    }
                };
            }

            if (request.Password.Length < 8)
            {
                return new ServiceResult
                {
                    Messages = new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "PasswordTooShort",
                            Message = "The provided password is too short. Please pick a longer password",
                            MessagePriority = MessagePriority.Error
                        }
                    }
                };
            }

            User user = new User();

            user = _mapper.Map<CreateUserRequest, User>(request, "CreateUser");

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return new ServiceResult();
        }

        public async Task<ServiceResult> Update(Guid Id, UpdateUserRequest request, CancellationToken cancellationToken)
        {
            //Check if email already exists
            var users = await _dbContext.Users.ToListAsync();

            var user = users.FirstOrDefault(u => u.Id == Id);

            if (user is null)
            {
                return new ServiceResult
                {
                    Messages = new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "NotFound",
                            Message = "The user was not found.",
                            MessagePriority = MessagePriority.Error
                        }
                    }
                };
            }


            if (!string.IsNullOrWhiteSpace(request.Email) && users.Any(u => u.Email == request.Email))
            {
                return new ServiceResult
                {
                    Messages = new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "EmailExists",
                            Message = "The provided email already exists.",
                            MessagePriority = MessagePriority.Error
                        }
                    }
                };
            }

            if (!string.IsNullOrWhiteSpace(request.Password) && users.Any(u => u.UserName == request.Email))
            {
                return new ServiceResult
                {
                    Messages = new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "UsernameExists",
                            Message = "The provided username already exists.",
                            MessagePriority = MessagePriority.Error
                        }
                    }
                };
            }

            if (!string.IsNullOrWhiteSpace(request.Password) && request.Password.Length < 8)
            {
                return new ServiceResult
                {
                    Messages = new List<ServiceMessage>
                    {
                        new ServiceMessage
                        {
                            Code = "PasswordTooShort",
                            Message = "The provided password is too short. Please pick a longer password",
                            MessagePriority = MessagePriority.Error
                        }
                    }
                };
            }

            _mapper.MapExistingDestination<UpdateUserRequest, User>(request, user, "UpdateUser");

            await _dbContext.SaveChangesAsync();

            return new ServiceResult();
        }

        public async Task<ServiceResult<List<User>>> GetAll(CancellationToken cancellationToken)
        {
            var users = await _dbContext.Users
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new ServiceResult<List<User>> { Data = users };
        }
    }
}
