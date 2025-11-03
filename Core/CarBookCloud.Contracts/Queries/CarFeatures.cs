using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetCarFeaturesByCarIdQuery(int CarID) : IRequest<List<CarFeatureResultDto>>;
    public record GetAllCarFeaturesQuery() : IRequest<List<CarFeatureResultDto>>;
    public record GetCarFeatureByIdQuery(int CarFeatureID) : IRequest<CarFeatureResultDto?>;
}
