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
    public class CreateCarDescriptionCommandHandler : IRequestHandler<CreateCarDescriptionCommand, CarDescriptionResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateCarDescriptionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarDescriptionResultDto> Handle(CreateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            if (string.IsNullOrWhiteSpace(dto.Details))
                throw new ArgumentException("Details boş olamaz.");

            var car = await _unitOfWork.Cars.GetByIdAsync(dto.CarID);
            if (car == null)
                throw new NotFoundException(nameof(Car), dto.CarID);

            var description = Domain.Entities.CarDescription.Create(dto.CarID, dto.Details);
            car.AddDescription(description);

            await _unitOfWork.CarDescriptions.AddAsync(description);
            await _unitOfWork.SaveEntitiesAsync();

            return new CarDescriptionResultDto
            {
                CarDescriptionID = description.CarDescriptionID,
                CarID = description.CarID,
                Details = description.Details
            };
        }
    }

    public class UpdateCarDescriptionCommandHandler : IRequestHandler<UpdateCarDescriptionCommand, CarDescriptionResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCarDescriptionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<CarDescriptionResultDto> Handle(UpdateCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var entity = await _unitOfWork.CarDescriptions.GetByIdAsync(dto.CarDescriptionID);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CarDescription), dto.CarDescriptionID);

            entity.SetDetails(dto.Details!);

            await _unitOfWork.CarDescriptions.UpdateAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return new CarDescriptionResultDto
            {
                CarDescriptionID = entity.CarDescriptionID,
                CarID = entity.CarID,
                Details = entity.Details
            };
        }
    }

    public class DeleteCarDescriptionCommandHandler : IRequestHandler<DeleteCarDescriptionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCarDescriptionCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCarDescriptionCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.CarDescriptions.GetByIdAsync(request.CarDescriptionID);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.CarDescription), request.CarDescriptionID);

            await _unitOfWork.CarDescriptions.DeleteAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
