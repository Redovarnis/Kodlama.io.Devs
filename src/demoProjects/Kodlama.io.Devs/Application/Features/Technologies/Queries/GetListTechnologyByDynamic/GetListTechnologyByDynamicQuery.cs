﻿using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Technologies.Queries.GetListTechnologyByDynamic
{
    public class GetListTechnologyByDynamicQuery : IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>, IRequest<TechnologyListModel>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetListTechnologyByDynamicQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Domain.Entities.Technology> models = await _technologyRepository
                    .GetListByDynamicAsync(
                        dynamic: request.Dynamic,
                        include: m => m.Include(c => c.ProgrammingLanguage),
                        index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize
                    );

                TechnologyListModel technology = _mapper.Map<TechnologyListModel>(models);
                return technology;
            }
        }
    }
}
