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
    public class GetAllBannersQueryHandler : IRequestHandler<GetAllBannersQuery, List<BannerResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllBannersQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<BannerResultDto>> Handle(GetAllBannersQuery request, CancellationToken cancellationToken)
        {
            var banners = await _unitOfWork.Banners.GetAllAsync();

            return banners.Select(b => new BannerResultDto
            {
                BannerID = b.BannerID,
                Title = b.Title,
                Description = b.Description,
                VideoDescription = b.VideoDescription,
                VideoUrl = b.VideoUrl
            }).ToList();
        }
    }

    public class GetBannerByIdQueryHandler : IRequestHandler<GetBannerByIdQuery, BannerResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetBannerByIdQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BannerResultDto?> Handle(GetBannerByIdQuery request, CancellationToken cancellationToken)
        {
            var banner = await _unitOfWork.Banners.GetByIdAsync(request.BannerID);
            if (banner == null) return null;

            return new BannerResultDto
            {
                BannerID = banner.BannerID,
                Title = banner.Title,
                Description = banner.Description,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl
            };
        }
    }
}
