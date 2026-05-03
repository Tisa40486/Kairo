using AutoMapper;
using KairoApi.Dto;
using KairoApi.Model;

namespace KairoApi.Business
{
    public class KairoApiProfile : Profile
    {
        public KairoApiProfile() 
        {
            CreateMap<TaskDao, TaskReponse>();
            CreateMap<TaskInput, TaskDao>();
        }
    }
}