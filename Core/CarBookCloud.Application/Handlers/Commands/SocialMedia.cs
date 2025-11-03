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
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommand, SocialMediaResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateSocialMediaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<SocialMediaResultDto> Handle(CreateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = Domain.Entities.SocialMedia.Create(
                request.Dto.Name,
                request.Dto.Url,
                request.Dto.Icon
            );

            await _unitOfWork.SocialMedias.AddAsync(socialMedia);
            await _unitOfWork.SaveEntitiesAsync();

            return new SocialMediaResultDto
            {
                SocialMediaID = socialMedia.SocialMediaID,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Icon = socialMedia.Icon
            };
        }
    }

    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, SocialMediaResultDto>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateSocialMediaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<SocialMediaResultDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetByIdAsync(request.Dto.SocialMediaID);
            if (socialMedia == null)
                throw new NotFoundException(nameof(Domain.Entities.SocialMedia), request.Dto.SocialMediaID);

            socialMedia.Update(
                request.Dto.Name,
                request.Dto.Url,
                request.Dto.Icon
            );

            await _unitOfWork.SocialMedias.UpdateAsync(socialMedia);
            await _unitOfWork.SaveEntitiesAsync();

            return new SocialMediaResultDto
            {
                SocialMediaID = socialMedia.SocialMediaID,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Icon = socialMedia.Icon
            };
        }
    }

    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteSocialMediaCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<Unit> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetByIdAsync(request.SocialMediaID);
            if (socialMedia == null)
                throw new NotFoundException(nameof(Domain.Entities.SocialMedia), request.SocialMediaID);

            await _unitOfWork.SocialMedias.DeleteAsync(socialMedia);
            await _unitOfWork.SaveEntitiesAsync();

            return Unit.Value;
        }
    }
}
