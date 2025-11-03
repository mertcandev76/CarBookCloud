using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Queries
{
    public record GetCarPricingsByCarIdQuery(int CarID) : IRequest<List<CarPricingResultDto>>;
    public record GetAllCarPricingsQuery() : IRequest<List<CarPricingResultDto>>;
    public record GetCarPricingByIdQuery(int CarPricingID) : IRequest<CarPricingResultDto?>;
}
