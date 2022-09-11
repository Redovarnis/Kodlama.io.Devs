using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Application.Services.Repositories;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRules
    {
        private readonly ITechnologyRepository _technologyRepository;
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public TechnologyBusinessRules(ITechnologyRepository technologyRepository, IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _technologyRepository = technologyRepository;
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageMustExistWhenAddingNewTechnologies(int programmingLanguageId)
        {
            var programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == programmingLanguageId);
            if (programmingLanguage == null) throw new BusinessException("Requested Programming Language does not exists.");
        }

        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Domain.Entities.Technology> result = await _technologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Technology Language exists.");
        }
        public void TechnologyShouldExistWhenRequested(Domain.Entities.Technology technology)
        {
            if (technology == null) throw new BusinessException("Requested Technology does not exists.");
        }

    }
}
