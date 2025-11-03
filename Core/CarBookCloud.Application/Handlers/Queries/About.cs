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
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, AboutResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAboutByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<AboutResultDto?> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var about = await _unitOfWork.Abouts.GetByIdAsync(request.AboutID);
            if (about == null) return null;

            return new AboutResultDto
            {
                AboutID = about.AboutID,
                Title = about.Title,
                Description = about.Description,
                ImageUrl = about.ImageUrl
            };
        }
    }
    public class GetAllAboutsQueryHandler : IRequestHandler<GetAllAboutsQuery, List<AboutResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllAboutsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<AboutResultDto>> Handle(GetAllAboutsQuery request, CancellationToken cancellationToken)
        {
            var abouts = await _unitOfWork.Abouts.GetAllAsync();
            return abouts.Select(a => new AboutResultDto
            {
                AboutID = a.AboutID,
                Title = a.Title,
                Description = a.Description,
                ImageUrl = a.ImageUrl
            }).ToList();
        }
    }
}
