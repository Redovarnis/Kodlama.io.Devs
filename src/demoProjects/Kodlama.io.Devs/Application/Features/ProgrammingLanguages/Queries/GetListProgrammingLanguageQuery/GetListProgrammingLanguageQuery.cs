﻿using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using MediatR;
using Application.Features.ProgrammingLanguages.Models;
using Application.Services.Repositories;
using Domain.Entities;

namespace Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguageQuery
{
    public class GetListProgrammingLanguageQuery : IRequest<ProgrammingLanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListProgrammingLanguageQueryHandler : IRequestHandler<GetListProgrammingLanguageQuery, ProgrammingLanguageListModel>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;

            public GetListProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
            }

            public async Task<ProgrammingLanguageListModel> Handle(GetListProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<ProgrammingLanguage> ProgrammingLanguages = await _programmingLanguageRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

                ProgrammingLanguageListModel mappedProgrammingLanguageListModel = _mapper.Map<ProgrammingLanguageListModel>(ProgrammingLanguages);

                return mappedProgrammingLanguageListModel;
            }
        }
    }
}
