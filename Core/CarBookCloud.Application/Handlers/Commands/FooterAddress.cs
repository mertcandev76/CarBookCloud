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
    public class CreateFooterAddressCommandHandler : IRequestHandler<CreateFooterAddressCommand, FooterAddressResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateFooterAddressCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<FooterAddressResultDto> Handle(CreateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = Domain.Entities.FooterAddress.Create(
                request.Dto.Description,
                request.Dto.Address,
                request.Dto.Phone,
                request.Dto.Email
            );

            await _unitOfWork.FooterAddresses.AddAsync(footerAddress);
            await _unitOfWork.SaveEntitiesAsync();

            return new FooterAddressResultDto
            {
                FooterAddressID = footerAddress.FooterAddressID,
                Description = footerAddress.Description,
                Address = footerAddress.Address,
                Phone = footerAddress.Phone,
                Email = footerAddress.Email
            };
        }
    }

    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand, FooterAddressResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateFooterAddressCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<FooterAddressResultDto> Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = await _unitOfWork.FooterAddresses.GetByIdAsync(request.Dto.FooterAddressID);
            if (footerAddress == null)
                throw new NotFoundException(nameof(Domain.Entities.FooterAddress), request.Dto.FooterAddressID);

            footerAddress.Update(
                request.Dto.Description,
                request.Dto.Address,
                request.Dto.Phone,
                request.Dto.Email
            );

            await _unitOfWork.FooterAddresses.UpdateAsync(footerAddress);
            await _unitOfWork.SaveEntitiesAsync();

            return new FooterAddressResultDto
            {
                FooterAddressID = footerAddress.FooterAddressID,
                Description = footerAddress.Description,
                Address = footerAddress.Address,
                Phone = footerAddress.Phone,
                Email = footerAddress.Email
            };
        }
    }

    public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteFooterAddressCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = await _unitOfWork.FooterAddresses.GetByIdAsync(request.FooterAddressID);
            if (footerAddress == null)
                throw new NotFoundException(nameof(Domain.Entities.FooterAddress), request.FooterAddressID);

            await _unitOfWork.FooterAddresses.DeleteAsync(footerAddress);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
