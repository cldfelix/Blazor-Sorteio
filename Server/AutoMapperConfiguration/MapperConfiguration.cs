using AutoMapper;
using Shared.Models;
using Shared.Responses;


namespace DadosBovespaApi.AutoMapperConfiguration
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<Concorrentes, ConcorrentesResult>();

            CreateMap<ResponseSorteioConcorrentes, ResponseSorteiosResult>()
                  .ForMember(dest =>
              dest.Deficiente, opt => opt.MapFrom(src => src.Deficiente))
                .ForMember(dest =>
              dest.Idoso, opt => opt.MapFrom(src => src.Idoso))
                   .ForMember(dest =>
              dest.Geral, opt => opt.MapFrom(src => src.Geral.ToList()));

            CreateMap<ResponseConcorrentes, ResponseConcorrentesResult>()
         .ForMember(dest =>
          dest.Deficientes, opt => opt.MapFrom(src => src.Deficientes.ToList()))
            .ForMember(dest =>
          dest.Idosos, opt => opt.MapFrom(src => src.Idosos.ToList()))
               .ForMember(dest =>
          dest.Geral, opt => opt.MapFrom(src => src.Geral.ToList()))
                  .ForMember(dest =>
          dest.Total, opt => opt.MapFrom(src => src.Total));









        }
    }
}