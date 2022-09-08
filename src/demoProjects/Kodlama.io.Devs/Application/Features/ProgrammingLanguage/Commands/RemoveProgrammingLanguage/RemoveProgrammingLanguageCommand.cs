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
                Domain.Entities.ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<Domain.Entities.ProgrammingLanguage>(request);
                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(mappedProgrammingLanguage);

                Domain.Entities.ProgrammingLanguage removedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedProgrammingLanguage);
                RemovedProgrammingLanguageDto removedProgrammingLanguageDto = _mapper.Map<RemovedProgrammingLanguageDto>(removedProgrammingLanguage);

                return removedProgrammingLanguageDto;
            }
        }
    }
}
