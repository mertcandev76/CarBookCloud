using CarBookCloud.Application.Extensions;
using CarBookCloud.Contracts.Commands;
using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.UnitOfWork;
using CarBookCloud.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Commands
{
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, CarResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarResultDto> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var car = Domain.Entities.Car.Create(dto.BrandID, dto.Model!);
            car = SetOptionalFields(car, dto);

            await _unitOfWork.Cars.AddAsync(car);
            await _unitOfWork.SaveEntitiesAsync();

            return MapToResultDto(car);
        }

        private static Car SetOptionalFields(Car car, CarCreateDto dto)
        {
            var type = car.GetType();
            type.GetProperty(nameof(Car.CoverImageUrl))?.SetValue(car, dto.CoverImageUrl);
            type.GetProperty(nameof(Car.Km))?.SetValue(car, dto.Km);
            type.GetProperty(nameof(Car.Transmission))?.SetValue(car, dto.Transmission);
            type.GetProperty(nameof(Car.Seat))?.SetValue(car, dto.Seat);
            type.GetProperty(nameof(Car.Lugage))?.SetValue(car, dto.Lugage);
            type.GetProperty(nameof(Car.Fuel))?.SetValue(car, dto.Fuel);
            type.GetProperty(nameof(Car.BigImageUrl))?.SetValue(car, dto.BigImageUrl);
            return car;
        }

        private static CarResultDto MapToResultDto(Car car)
        {
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
                BigImageUrl = car.BigImageUrl
            };
        }
    }

    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, CarResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarResultDto> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;
            var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarID);
            if (car == null)
                throw new NotFoundException(nameof(Domain.Entities.Car), dto.CarID);

            var type = car.GetType();
            type.GetProperty(nameof(Car.BrandID))?.SetValue(car, dto.BrandID);
            type.GetProperty(nameof(Car.Model))?.SetValue(car, dto.Model);
            type.GetProperty(nameof(Car.CoverImageUrl))?.SetValue(car, dto.CoverImageUrl);
            type.GetProperty(nameof(Car.Km))?.SetValue(car, dto.Km);
            type.GetProperty(nameof(Car.Transmission))?.SetValue(car, dto.Transmission);
            type.GetProperty(nameof(Car.Seat))?.SetValue(car, dto.Seat);
            type.GetProperty(nameof(Car.Lugage))?.SetValue(car, dto.Lugage);
            type.GetProperty(nameof(Car.Fuel))?.SetValue(car, dto.Fuel);
            type.GetProperty(nameof(Car.BigImageUrl))?.SetValue(car, dto.BigImageUrl);

            await _unitOfWork.Cars.UpdateAsync(car);
            await _unitOfWork.SaveEntitiesAsync();

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
                BigImageUrl = car.BigImageUrl
            };
        }
    }

    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            var car = await _unitOfWork.Cars.GetByIdAsync(request.CarID);
            if (car == null)
                throw new NotFoundException(nameof(Domain.Entities.Car), request.CarID);

            await _unitOfWork.Cars.DeleteAsync(car);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
