using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetCarDescriptionsByCarIdQuery(int CarID) : IRequest<List<CarDescriptionResultDto>>;
    public record GetCarDescriptionByIdQuery(int CarDescriptionID) : IRequest<CarDescriptionResultDto?>;
    public record GetAllCarDescriptionsQuery() : IRequest<List<CarDescriptionResultDto>>;
}
