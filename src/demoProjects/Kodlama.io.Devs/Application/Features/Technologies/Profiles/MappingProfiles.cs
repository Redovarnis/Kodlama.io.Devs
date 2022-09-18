using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.RemoveTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, CreatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();

            CreateMap<Technology, RemovedTechnologyDto>().ReverseMap();
            CreateMap<Technology, RemoveTechnologyCommand>().ReverseMap();

            CreateMap<Technology, UpdatedTechnologyDto>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();

            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ReverseMap();

            CreateMap<Technology, TechnologyListDto>().
                ForMember(c => c.ProgrammingLanguageName,
                opt => opt.MapFrom(c => 
                    c.ProgrammingLanguage.Name))
                .ReverseMap();
            
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
        }
    }
}
