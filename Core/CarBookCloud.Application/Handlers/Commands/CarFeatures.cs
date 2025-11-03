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
    public class CreateCarFeatureCommandHandler : IRequestHandler<CreateCarFeatureCommand, CarFeatureResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarFeatureResultDto> Handle(CreateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarID);
            if (car == null)
                throw new NotFoundException(nameof(Car), dto.CarID);

            var feature = await _unitOfWork.Features.GetByIdAsync(dto.FeatureID);
            if (feature == null)
                throw new NotFoundException(nameof(Feature), dto.FeatureID);

            var entity = CarFeature.Create(dto.CarID, dto.FeatureID, dto.Available);

            car.AddFeature(entity);

            await _unitOfWork.CarFeatures.AddAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return new CarFeatureResultDto
            {
                CarFeatureID = entity.CarFeatureID,
                CarID = entity.CarID,
                FeatureID = entity.FeatureID,
                Available = entity.Available
            };
        }
    }

    public class UpdateCarFeatureCommandHandler : IRequestHandler<UpdateCarFeatureCommand, CarFeatureResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarFeatureResultDto> Handle(UpdateCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var entity = await _unitOfWork.CarFeatures.GetByIdAsync(dto.CarFeatureID);
            if (entity == null)
                throw new NotFoundException(nameof(CarFeature), dto.CarFeatureID);

            entity.SetAvailable(dto.Available);

            await _unitOfWork.CarFeatures.UpdateAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return new CarFeatureResultDto
            {
                CarFeatureID = entity.CarFeatureID,
                CarID = entity.CarID,
                FeatureID = entity.FeatureID,
                Available = entity.Available
            };
        }
    }


    public class DeleteCarFeatureCommandHandler : IRequestHandler<DeleteCarFeatureCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCarFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CarFeatures.GetByIdAsync(request.CarFeatureID);
            if (entity == null)
                throw new NotFoundException(nameof(CarFeature), request.CarFeatureID);

            await _unitOfWork.CarFeatures.DeleteAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
