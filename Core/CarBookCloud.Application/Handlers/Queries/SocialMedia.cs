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
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, SocialMediaResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetSocialMediaByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<SocialMediaResultDto?> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var socialMedia = await _unitOfWork.SocialMedias.GetByIdAsync(request.SocialMediaID);
            if (socialMedia == null) return null;

            return new SocialMediaResultDto
            {
                SocialMediaID = socialMedia.SocialMediaID,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Icon = socialMedia.Icon
            };
        }
    }

    public class GetAllSocialMediasQueryHandler : IRequestHandler<GetAllSocialMediasQuery, List<SocialMediaResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllSocialMediasQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<SocialMediaResultDto>> Handle(GetAllSocialMediasQuery request, CancellationToken cancellationToken)
        {
            var list = await _unitOfWork.SocialMedias.GetAllAsync();
            return list.Select(s => new SocialMediaResultDto
            {
                SocialMediaID = s.SocialMediaID,
                Name = s.Name,
                Url = s.Url,
                Icon = s.Icon
            }).ToList();
        }
    }
}
