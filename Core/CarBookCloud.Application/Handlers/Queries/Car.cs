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
    public class GetAllCarsQueryHandler : IRequestHandler<GetAllCarsQuery, List<CarResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllCarsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<CarResultDto>> Handle(GetAllCarsQuery request, CancellationToken cancellationToken)
        {
            var cars = await _unitOfWork.Cars.GetAllWithIncludesAsync();

            return cars.Select(c => new CarResultDto
            {
                CarID = c.CarID,
                BrandID = c.BrandID,
                Model = c.Model,
                CoverImageUrl = c.CoverImageUrl,
                Km = c.Km,
                Transmission = c.Transmission,
                Seat = c.Seat,
                Lugage = c.Lugage,
                Fuel = c.Fuel,
                BigImageUrl = c.BigImageUrl,
                CarFeatures = c.CarFeatures.Select(f => new CarFeatureResultDto
                {
                    FeatureID = f.FeatureID,
                    Available = f.Available
                }).ToList(),
                CarDescriptions = c.CarDescriptions.Select(d => new CarDescriptionResultDto
                {
                    CarDescriptionID = d.CarDescriptionID,
                    Details = d.Details
                }).ToList(),
                CarPricings = c.CarPricings.Select(p => new CarPricingResultDto
                {
                    PricingID = p.PricingID,
                    Amount = p.Amount.Amount
                }).ToList()
            }).ToList();
        }
    }

    public class GetCarByIdQueryHandler : IRequestHandler<GetCarByIdQuery, CarResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetCarByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarResultDto?> Handle(GetCarByIdQuery request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.Cars.GetByIdWithIncludesAsync(request.CarID);
            if (car == null) return null;

            return new CarResultDto
            {
                CarID = car.CarID,
                BrandID = car.BrandID,
                Model = car.Model,
                CoverImageUrl = car.CoverImageUrl,
                Km = car.Km,
                Transmission = car.Transmission,
                Seat = car.Seat,
                Lugage = car.Lugage,
                Fuel = car.Fuel,
                BigImageUrl = car.BigImageUrl,
                CarFeatures = car.CarFeatures.Select(f => new CarFeatureResultDto
                {
                    FeatureID = f.FeatureID,
                    Available = f.Available
                }).ToList(),
                CarDescriptions = car.CarDescriptions.Select(d => new CarDescriptionResultDto
                {
                    CarDescriptionID = d.CarDescriptionID,
                    Details = d.Details
                }).ToList(),
                CarPricings = car.CarPricings.Select(p => new CarPricingResultDto
                {
                    PricingID = p.PricingID,
                    Amount = p.Amount.Amount
                }).ToList()
            };
        }
    }
}
