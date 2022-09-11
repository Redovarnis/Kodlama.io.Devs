using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.RemoveTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;

namespace Application.Features.Technology.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<Domain.Entities.Technology, RemovedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, RemoveTechnologyCommand>().ReverseMap();

            CreateMap<Domain.Entities.Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Domain.Entities.Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Domain.Entities.Technology, TechnologyListDto>().ReverseMap();

            CreateMap<Domain.Entities.Technology, TechnologyListDto>().
                ForMember(c => c.ProgrammingLanguageName,
                opt => opt.MapFrom(c => 
                    c.ProgrammingLanguage.Name))
                .ReverseMap();
            
            CreateMap<IPaginate<Domain.Entities.Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}
