using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic
{
    public partial class GetListModelByDynamicQuery
    {
        public class GetListModelByDynamicQueryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelByDynamicQueryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync(
                                                                            request.Dynamic,
                                                                            include: m => m.Include(b => b.Brand),
                                                                            index: request.PageRequest.Page,
                                                                            size: request.PageRequest.PageSize);


                ModelListModel mappedModels = _mapper.Map<ModelListModel>(models);
                return mappedModels;
            }
        }
    }
}
