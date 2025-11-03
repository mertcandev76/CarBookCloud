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
    public class CreateBannerCommandHandler : IRequestHandler<CreateBannerCommand, BannerResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateBannerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BannerResultDto> Handle(CreateBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = Domain.Entities.Banner.Create(
                request.Dto.Title!,
                request.Dto.Description,
                request.Dto.VideoDescription,
                request.Dto.VideoUrl
            );

            await _unitOfWork.Banners.AddAsync(banner);
            await _unitOfWork.SaveEntitiesAsync();

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

    public class UpdateBannerCommandHandler : IRequestHandler<UpdateBannerCommand, BannerResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBannerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BannerResultDto> Handle(UpdateBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _unitOfWork.Banners.GetByIdAsync(request.Dto.BannerID);
            if (banner == null)
                throw new NotFoundException(nameof(Domain.Entities.Banner), request.Dto.BannerID);

            banner.SetTitle(request.Dto.Title!);
            banner.SetDescription(request.Dto.Description);
            banner.SetVideoDescription(request.Dto.VideoDescription);
            banner.SetVideoUrl(request.Dto.VideoUrl);

            await _unitOfWork.Banners.UpdateAsync(banner);
            await _unitOfWork.SaveEntitiesAsync();

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

    public class DeleteBannerCommandHandler : IRequestHandler<DeleteBannerCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBannerCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteBannerCommand request, CancellationToken cancellationToken)
        {
            var banner = await _unitOfWork.Banners.GetByIdAsync(request.BannerID);
            if (banner == null)
                throw new NotFoundException(nameof(Domain.Entities.Banner), request.BannerID);

            await _unitOfWork.Banners.DeleteAsync(banner);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
