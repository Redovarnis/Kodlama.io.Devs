using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.Technologies.Commands.RemoveTechnology
{
    public class RemoveTechnologyCommand : IRequest<RemovedTechnologyDto>
    {
        public int Id { get; set; }
        public class RemoveTechnologyCommandHandler : IRequestHandler<RemoveTechnologyCommand, RemovedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public RemoveTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<RemovedTechnologyDto> Handle(RemoveTechnologyCommand request, CancellationToken cancellationToken)
            {
                Domain.Entities.Technology mappedTechnology = _mapper.Map<Domain.Entities.Technology>(request);
                _technologyBusinessRules.TechnologyShouldExistWhenRequested(mappedTechnology);

                Domain.Entities.Technology removedTechnology = await _technologyRepository.DeleteAsync(mappedTechnology);
                RemovedTechnologyDto removedTechnologyDto = _mapper.Map<RemovedTechnologyDto>(removedTechnology);

                return removedTechnologyDto;
            }
        }
    }
}
