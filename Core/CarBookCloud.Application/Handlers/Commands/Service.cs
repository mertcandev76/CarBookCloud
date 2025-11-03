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
    public class CreateServiceCommandHandler : IRequestHandler<CreateServiceCommand, ServiceResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateServiceCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResultDto> Handle(CreateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = Domain.Entities.Service.Create(
                request.Dto.Title,
                request.Dto.Description,
                request.Dto.IconUrl
            );

            await _unitOfWork.Services.AddAsync(service);
            await _unitOfWork.SaveEntitiesAsync();

            return new ServiceResultDto
            {
                ServiceID = service.ServiceID,
                Title = service.Title,
                Description = service.Description,
                IconUrl = service.IconUrl
            };
        }
    }

    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommand, ServiceResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateServiceCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResultDto> Handle(UpdateServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(request.Dto.ServiceID);
            if (service == null)
                throw new NotFoundException(nameof(Domain.Entities.Service), request.Dto.ServiceID);

            service.Update(
                request.Dto.Title,
                request.Dto.Description,
                request.Dto.IconUrl
            );

            await _unitOfWork.Services.UpdateAsync(service);
            await _unitOfWork.SaveEntitiesAsync();

            return new ServiceResultDto
            {
                ServiceID = service.ServiceID,
                Title = service.Title,
                Description = service.Description,
                IconUrl = service.IconUrl
            };
        }
    }

    public class DeleteServiceCommandHandler : IRequestHandler<DeleteServiceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteServiceCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteServiceCommand request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(request.ServiceID);
            if (service == null)
                throw new NotFoundException(nameof(Domain.Entities.Service), request.ServiceID);

            await _unitOfWork.Services.DeleteAsync(service);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
