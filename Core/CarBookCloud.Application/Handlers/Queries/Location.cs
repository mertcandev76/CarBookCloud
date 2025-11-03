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
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, LocationResultDto?>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetLocationByIdQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<LocationResultDto?> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var location = await _unitOfWork.Locations.GetByIdAsync(request.LocationID);
            if (location == null) return null;

            return new LocationResultDto
            {
                LocationID = location.LocationID,
                Name = location.Name
            };
        }
    }

    public class GetAllLocationsQueryHandler : IRequestHandler<GetAllLocationsQuery, List<LocationResultDto>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllLocationsQueryHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<List<LocationResultDto>> Handle(GetAllLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await _unitOfWork.Locations.GetAllAsync();
            return locations.Select(l => new LocationResultDto
            {
                LocationID = l.LocationID,
                Name = l.Name
            }).ToList();
        }
    }
}
