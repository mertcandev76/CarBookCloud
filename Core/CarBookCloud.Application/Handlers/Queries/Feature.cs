using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.Queries;
using CarBookCloud.Contracts.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Queries
{
    public class GetAllFeaturesQueryHandler : IRequestHandler<GetAllFeaturesQuery, List<FeatureResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFeaturesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FeatureResultDto>> Handle(GetAllFeaturesQuery request, CancellationToken cancellationToken)
        {
            var features = await _unitOfWork.Features.GetAllWithIncludesAsync();

            return features.Select(f => new FeatureResultDto
            {
                FeatureID = f.FeatureID,
                Name = f.Name
            }).ToList();
        }
    }

    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, FeatureResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFeatureByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FeatureResultDto?> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var f = await _unitOfWork.Features.GetByIdWithIncludesAsync(request.FeatureID);
            if (f == null) return null;

            return new FeatureResultDto
            {
                FeatureID = f.FeatureID,
                Name = f.Name
            };
        }
    }
}
