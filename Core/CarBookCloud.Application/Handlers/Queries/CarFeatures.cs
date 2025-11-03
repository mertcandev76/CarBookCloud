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
    public class GetCarFeatureByIdQueryHandler : IRequestHandler<GetCarFeatureByIdQuery, CarFeatureResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarFeatureByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarFeatureResultDto?> Handle(GetCarFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var carFeature = await _unitOfWork.CarFeatures.GetByIdWithIncludesAsync(request.CarFeatureID);
            if (carFeature == null)
                return null;

            return new CarFeatureResultDto
            {
                CarFeatureID = carFeature.CarFeatureID,
                CarID = carFeature.CarID,
                FeatureID = carFeature.FeatureID,
                Available = carFeature.Available
            };
        }
    }

    public class GetAllCarFeaturesQueryHandler : IRequestHandler<GetAllCarFeaturesQuery, List<CarFeatureResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarFeaturesQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarFeatureResultDto>> Handle(GetAllCarFeaturesQuery request, CancellationToken cancellationToken)
        {
            var carFeatures = await _unitOfWork.CarFeatures.GetAllWithIncludesAsync();

            return carFeatures.Select(cf => new CarFeatureResultDto
            {
                CarFeatureID = cf.CarFeatureID,
                CarID = cf.CarID,
                FeatureID = cf.FeatureID,
                Available = cf.Available
            }).ToList();
        }
    }
}
