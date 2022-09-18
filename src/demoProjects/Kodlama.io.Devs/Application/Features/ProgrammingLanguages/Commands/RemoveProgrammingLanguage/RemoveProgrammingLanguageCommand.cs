using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Commands.RemoveProgrammingLanguage
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
                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(mappedProgrammingLanguage);

                ProgrammingLanguage removedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(mappedProgrammingLanguage);
                RemovedProgrammingLanguageDto removedProgrammingLanguageDto = _mapper.Map<RemovedProgrammingLanguageDto>(removedProgrammingLanguage);

                return removedProgrammingLanguageDto;
            }
        }
    }
}
