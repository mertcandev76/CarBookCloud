using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateCarPricingCommand(CarPricingCreateDto Dto) : IRequest<CarPricingResultDto>;
    public record DeleteCarPricingCommand(int CarPricingID) : IRequest<Unit>;
    public record UpdateCarPricingCommand(CarPricingUpdateDto Dto) : IRequest<CarPricingResultDto>;
}
