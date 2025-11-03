using CarBookCloud.Application.Extensions;
using CarBookCloud.Contracts.Commands;
using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.UnitOfWork;
using CarBookCloud.Domain.Entities;
using CarBookCloud.Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Commands
{
    public class CreateCarPricingCommandHandler : IRequestHandler<CreateCarPricingCommand, CarPricingResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarPricingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarPricingResultDto> Handle(CreateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            if (dto.Amount <= 0)
                throw new ArgumentException("Fiyat 0'dan büyük olmalıdır.");

            var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarID);
            if (car == null)
                throw new NotFoundException(nameof(Car), dto.CarID);

            var pricing = await _unitOfWork.Pricings.GetByIdAsync(dto.PricingID);
            if (pricing == null)
                throw new NotFoundException(nameof(Pricing), dto.PricingID);

            var price = new Price(dto.Amount);
            var carPricing = Domain.Entities.CarPricing.Create(price);

            typeof(Domain.Entities.CarPricing)
                .GetProperty("CarID")!
                .SetValue(carPricing, dto.CarID);

            typeof(Domain.Entities.CarPricing)
                .GetProperty("PricingID")!
                .SetValue(carPricing, dto.PricingID);

            await _unitOfWork.CarPricings.AddAsync(carPricing);
            await _unitOfWork.SaveEntitiesAsync();

            return new CarPricingResultDto
            {
                CarPricingID = carPricing.CarPricingID,
                CarID = dto.CarID,
                PricingID = dto.PricingID,
                Amount = dto.Amount
            };
        }
    }


    public class UpdateCarPricingCommandHandler : IRequestHandler<UpdateCarPricingCommand, CarPricingResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarPricingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarPricingResultDto> Handle(UpdateCarPricingCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var entity = await _unitOfWork.CarPricings.GetByIdAsync(dto.CarPricingID);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CarPricing), dto.CarPricingID);

            entity.SetAmount(new Price(dto.Amount));

            await _unitOfWork.CarPricings.UpdateAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return new CarPricingResultDto
            {
                CarPricingID = entity.CarPricingID,
                CarID = entity.CarID,
                PricingID = entity.PricingID,
                Amount = dto.Amount
            };
        }
    }


    public class DeleteCarPricingCommandHandler : IRequestHandler<DeleteCarPricingCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarPricingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCarPricingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CarPricings.GetByIdAsync(request.CarPricingID);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CarPricing), request.CarPricingID);

            await _unitOfWork.CarPricings.DeleteAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
