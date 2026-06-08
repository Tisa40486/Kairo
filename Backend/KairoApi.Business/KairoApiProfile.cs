using AutoMapper;
using KairoApi.Dto;
using KairoApi.Model;
using KairoApi.Model.LKP;

namespace KairoApi.Business
{
    public class KairoApiProfile : Profile
    {
        public KairoApiProfile()
        {
            CreateMap<TaskDao, TaskReponse>();
            CreateMap<TaskInput, TaskDao>();


            CreateMap<UserDao, UserResponse>();
            CreateMap<UserInput, UserDao>();

        }
    }
}