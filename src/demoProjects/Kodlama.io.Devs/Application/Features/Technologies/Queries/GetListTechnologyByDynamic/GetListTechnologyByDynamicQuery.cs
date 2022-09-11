using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic
{
    public class GetListTechnologyByDynamicQuery : IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListTechnologyByDynamicQuery, TechnologyListModel>, IRequest<TechnologyListModel>
        {
            private readonly ITechnologyRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelByDynamicQueryHandler(ITechnologyRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyListModel> Handle(GetListTechnologyByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Technology> models = await _modelRepository
                    .GetListByDynamicAsync(
                        dynamic: request.Dynamic,
                        include: m => m.Include(c => c.ProgrammingLanguage),
                        index: request.PageRequest.Page,
                        size: request.PageRequest.PageSize
                    );

                TechnologyListModel model = _mapper.Map<TechnologyListModel>(models);
                return model;
            }
        }
    }
}
