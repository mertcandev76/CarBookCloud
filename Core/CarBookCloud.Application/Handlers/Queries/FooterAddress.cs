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
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, FooterAddressResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetFooterAddressByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<FooterAddressResultDto?> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var footerAddress = await _unitOfWork.FooterAddresses.GetByIdAsync(request.FooterAddressID);
            if (footerAddress == null) return null;

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

    public class GetAllFooterAddressesQueryHandler : IRequestHandler<GetAllFooterAddressesQuery, List<FooterAddressResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllFooterAddressesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<FooterAddressResultDto>> Handle(GetAllFooterAddressesQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.FooterAddresses.GetAllAsync();
            return list.Select(fa => new FooterAddressResultDto
            {
                FooterAddressID = fa.FooterAddressID,
                Description = fa.Description,
                Address = fa.Address,
                Phone = fa.Phone,
                Email = fa.Email
            }).ToList();
        }
    }
}
