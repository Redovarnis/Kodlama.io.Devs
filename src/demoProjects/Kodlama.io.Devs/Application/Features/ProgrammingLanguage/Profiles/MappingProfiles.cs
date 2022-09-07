using AutoMapper;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.ProgrammingLanguage.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Models;
using Application.Features.ProgrammingLanguage.Commands.RemoveProgrammingLanguage;
using Application.Features.ProgrammingLanguage.Commands.UpdateProgrammingLanguage;

namespace Application.Features.ProgrammingLanguage.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Domain.Entities.ProgrammingLanguage, CreatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, CreateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<Domain.Entities.ProgrammingLanguage, RemovedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, RemoveProgrammingLanguageCommand>().ReverseMap();

            CreateMap<Domain.Entities.ProgrammingLanguage, UpdatedProgrammingLanguageDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, UpdateProgrammingLanguageCommand>().ReverseMap();

            CreateMap<IPaginate<Domain.Entities.ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();

            CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<Domain.Entities.ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();
        }
    }
}
