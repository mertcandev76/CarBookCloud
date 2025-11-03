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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, ServiceResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetServiceByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResultDto?> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var service = await _unitOfWork.Services.GetByIdAsync(request.ServiceID);
            if (service == null) return null;

            return new ServiceResultDto
            {
                ServiceID = service.ServiceID,
                Title = service.Title,
                Description = service.Description,
                IconUrl = service.IconUrl
            };
        }
    }

    public class GetAllServicesQueryHandler : IRequestHandler<GetAllServicesQuery, List<ServiceResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllServicesQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<ServiceResultDto>> Handle(GetAllServicesQuery request, CancellationToken cancellationToken)
        {
            var services = await _unitOfWork.Services.GetAllAsync();
            return services.Select(s => new ServiceResultDto
            {
                ServiceID = s.ServiceID,
                Title = s.Title,
                Description = s.Description,
                IconUrl = s.IconUrl
            }).ToList();
        }
    }
}
