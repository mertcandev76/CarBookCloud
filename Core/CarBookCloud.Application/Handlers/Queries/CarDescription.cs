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
    public class GetAllCarDescriptionsQueryHandler : IRequestHandler<GetAllCarDescriptionsQuery, List<CarDescriptionResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarDescriptionsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarDescriptionResultDto>> Handle(GetAllCarDescriptionsQuery request, CancellationToken cancellationToken)
        {
            var descriptions = await _unitOfWork.CarDescriptions.GetAllWithCarsAsync();

            return descriptions.Select(d => new CarDescriptionResultDto
            {
                CarDescriptionID = d.CarDescriptionID,
                CarID = d.CarID,
                Details = d.Details
            }).ToList();
        }
    }

    public class GetCarDescriptionByIdQueryHandler : IRequestHandler<GetCarDescriptionByIdQuery, CarDescriptionResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarDescriptionByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarDescriptionResultDto?> Handle(GetCarDescriptionByIdQuery request, CancellationToken cancellationToken)
        {
            var d = await _unitOfWork.CarDescriptions.GetByIdWithCarAsync(request.CarDescriptionID);
            if (d == null) return null;

            return new CarDescriptionResultDto
            {
                CarDescriptionID = d.CarDescriptionID,
                CarID = d.CarID,
                Details = d.Details
            };
        }
    }
}
