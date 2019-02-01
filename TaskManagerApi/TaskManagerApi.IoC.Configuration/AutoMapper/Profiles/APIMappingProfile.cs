using AutoMapper;
using DC = TaskManagerApi.API.DataContracts;
using S = TaskManagerApi.Services.Model;

namespace TaskManagerApi.IoC.Configuration.AutoMapper.Profiles
{
    public class APIMappingProfile : Profile
    {
        public APIMappingProfile()
        {
            CreateMap<DC.User, S.User>().ReverseMap();
            CreateMap<DC.Adress, S.Adress>().ReverseMap();
        }
    }
}
