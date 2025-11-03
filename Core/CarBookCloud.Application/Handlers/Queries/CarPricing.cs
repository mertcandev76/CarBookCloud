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
    public class GetAllCarPricingsQueryHandler : IRequestHandler<GetAllCarPricingsQuery, List<CarPricingResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarPricingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarPricingResultDto>> Handle(GetAllCarPricingsQuery request, CancellationToken cancellationToken)
        {
            var pricings = await _unitOfWork.CarPricings.GetAllWithIncludesAsync();

            return pricings.Select(p => new CarPricingResultDto
            {
                CarPricingID = p.CarPricingID,
                CarID = p.CarID,
                PricingID = p.PricingID,
                Amount = p.Amount.Amount
            }).ToList();
        }
    }


    public class GetCarPricingByIdQueryHandler : IRequestHandler<GetCarPricingByIdQuery, CarPricingResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarPricingByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarPricingResultDto?> Handle(GetCarPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CarPricings.GetByIdWithIncludesAsync(request.CarPricingID);
            if (entity == null)
                return null;

            return new CarPricingResultDto
            {
                CarPricingID = entity.CarPricingID,
                CarID = entity.CarID,
                PricingID = entity.PricingID,
                Amount = entity.Amount.Amount
            };
        }
    }
}
