using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetFeatureByIdQuery(int FeatureID) : IRequest<FeatureResultDto?>;
    public record GetAllFeaturesQuery() : IRequest<List<FeatureResultDto>>;
}
