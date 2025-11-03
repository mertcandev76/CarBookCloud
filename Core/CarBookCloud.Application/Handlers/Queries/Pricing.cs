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
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, PricingResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetPricingByIdQueryHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<PricingResultDto?> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var pricing = await _unitOfWork.Pricings.GetByIdAsync(request.PricingID);
            if (pricing == null) return null;

            return new PricingResultDto
            {
                PricingID = pricing.PricingID,
                Name = pricing.Name
            };
        }
    }


    public class GetAllPricingsQueryHandler : IRequestHandler<GetAllPricingsQuery, List<PricingResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllPricingsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<PricingResultDto>> Handle(GetAllPricingsQuery request, CancellationToken cancellationToken)
        {
            var pricings = await _unitOfWork.Pricings.GetAllAsync();

            return pricings.Select(p => new PricingResultDto
            {
                PricingID = p.PricingID,
                Name = p.Name
            }).ToList();
        }
    }
}
