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
    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, List<BrandResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBrandsQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BrandResultDto>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var brands = await _unitOfWork.Brands.GetAllWithIncludesAsync();

            return brands.Select(b => new BrandResultDto
            {
                BrandID = b.BrandID,
                Name = b.Name
            }).ToList();
        }
    }

    public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, BrandResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBrandByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BrandResultDto?> Handle(GetBrandByIdQuery request, CancellationToken cancellationToken)
        {
            var brand = await _unitOfWork.Brands.GetByIdWithIncludesAsync(request.BrandID);
            if (brand == null) return null;

            return new BrandResultDto
            {
                BrandID = brand.BrandID,
                Name = brand.Name
            };
        }
    }
}
