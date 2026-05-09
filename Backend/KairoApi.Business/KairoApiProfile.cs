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
            CreateMap<TaskDao, TaskReponse>()
                .ForMember(
                dest => dest.Status,
                opt => opt.MapFrom(src => src.LKP_StatusDao)
                );
            CreateMap<TaskInput, TaskDao>();



            CreateMap<LKP_StatusDao, StatusResponse>();
        }
    }
}