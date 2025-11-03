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
    public class CreatePricingCommandHandler : IRequestHandler<CreatePricingCommand, PricingResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePricingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PricingResultDto> Handle(CreatePricingCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var entity = Pricing.Create(dto.Name);

            await _unitOfWork.Pricings.AddAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return new PricingResultDto
            {
                PricingID = entity.PricingID,
                Name = entity.Name
            };
        }
    }

    public class UpdatePricingCommandHandler : IRequestHandler<UpdatePricingCommand, PricingResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdatePricingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PricingResultDto> Handle(UpdatePricingCommand request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            var entity = await _unitOfWork.Pricings.GetByIdAsync(dto.PricingID);
            if (entity == null)
                throw new NotFoundException(nameof(Pricing), dto.PricingID);

            entity.Update(dto.Name);

            await _unitOfWork.Pricings.UpdateAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return new PricingResultDto
            {
                PricingID = entity.PricingID,
                Name = entity.Name
            };
        }
    }

    public class DeletePricingCommandHandler : IRequestHandler<DeletePricingCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePricingCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeletePricingCommand request, CancellationToken cancellationToken)
        {
            var entity = await _unitOfWork.Pricings.GetByIdAsync(request.PricingID);
            if (entity == null)
                throw new NotFoundException(nameof(Pricing), request.PricingID);

            await _unitOfWork.Pricings.DeleteAsync(entity);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
