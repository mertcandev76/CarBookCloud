using CarBookCloud.Application.Extensions;
using CarBookCloud.Contracts.Commands;
using CarBookCloud.Contracts.DTOs;
using CarBookCloud.Contracts.UnitOfWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Application.Handlers.Commands
{
    public class CreateLocationCommandHandler : IRequestHandler<CreateLocationCommand, LocationResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateLocationCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<LocationResultDto> Handle(CreateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = Domain.Entities.Location.Create(request.Dto.Name);

            await _unitOfWork.Locations.AddAsync(location);
            await _unitOfWork.SaveEntitiesAsync();

            return new LocationResultDto
            {
                LocationID = location.LocationID,
                Name = location.Name
            };
        }
    }

    public class UpdateLocationCommandHandler : IRequestHandler<UpdateLocationCommand, LocationResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateLocationCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<LocationResultDto> Handle(UpdateLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(request.Dto.LocationID);
            if (location == null)
                throw new NotFoundException(nameof(Domain.Entities.Location), request.Dto.LocationID);

            location.Update(request.Dto.Name);

            await _unitOfWork.Locations.UpdateAsync(location);
            await _unitOfWork.SaveEntitiesAsync();

            return new LocationResultDto
            {
                LocationID = location.LocationID,
                Name = location.Name
            };
        }
    }

    public class DeleteLocationCommandHandler : IRequestHandler<DeleteLocationCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteLocationCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteLocationCommand request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(request.LocationID);
            if (location == null)
                throw new NotFoundException(nameof(Domain.Entities.Location), request.LocationID);

            await _unitOfWork.Locations.DeleteAsync(location);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
