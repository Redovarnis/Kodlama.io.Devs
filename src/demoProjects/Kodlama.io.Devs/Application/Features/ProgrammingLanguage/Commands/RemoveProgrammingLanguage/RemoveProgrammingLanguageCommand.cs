using Application.Features.ProgrammingLanguage.Dtos;
using Application.Features.ProgrammingLanguage.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguage.Commands.RemoveProgrammingLanguage
{
    public class RemoveProgrammingLanguageCommand : IRequest<RemovedProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class RemoveProgrammingLanguageCommandHandler : IRequestHandler<RemoveProgrammingLanguageCommand, RemovedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public RemoveProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<RemovedProgrammingLanguageDto> Handle(RemoveProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(p => p.Id == request.Id);

                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);
                Domain.Entities.ProgrammingLanguage result = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
                RemovedProgrammingLanguageDto removedProgrammingLanguageDto = _mapper.Map<RemovedProgrammingLanguageDto>(result);

                return removedProgrammingLanguageDto;
            }
        }
    }
}
