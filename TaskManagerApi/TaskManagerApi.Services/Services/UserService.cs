using AutoMapper;
using TaskManagerApi.API.Common.Settings;
using TaskManagerApi.Services.Contracts;
using TaskManagerApi.Services.Model;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace TaskManagerApi.Services
{
    public class UserService : IUserService
    {
        private AppSettings _settings;
        private readonly IMapper _mapper;

        public UserService(IOptions<AppSettings> settings, IMapper mapper)
        {
            _settings = settings?.Value;
            _mapper = mapper;
        }

        public async Task<User> CreateAsync(User user)
        {
            return user;
        }

        public async Task<bool> UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<User> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
