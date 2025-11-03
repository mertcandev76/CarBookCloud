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
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand, FeatureResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FeatureResultDto> Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ArgumentException("Feature name boş olamaz.");

            var feature = Domain.Entities.Feature.Create(dto.Name);
            await _unitOfWork.Features.AddAsync(feature);
            await _unitOfWork.SaveEntitiesAsync();

            return new FeatureResultDto
            {
                FeatureID = feature.FeatureID,
                Name = feature.Name
            };
        }
    }

    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand, FeatureResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<FeatureResultDto> Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var entity = await _unitOfWork.Features.GetByIdAsync(dto.FeatureID);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Feature), dto.FeatureID);

            entity.Update(dto.Name);

            await _unitOfWork.Features.UpdateAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return new FeatureResultDto
            {
                FeatureID = entity.FeatureID,
                Name = entity.Name
            };
        }
    }

    public class DeleteFeatureCommandHandler : IRequestHandler<DeleteFeatureCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFeatureCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteFeatureCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Features.GetByIdAsync(request.FeatureID);
            if (entity == null)
                throw new NotFoundException(nameof(Domain.Entities.Feature), request.FeatureID);

            await _unitOfWork.Features.DeleteAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
