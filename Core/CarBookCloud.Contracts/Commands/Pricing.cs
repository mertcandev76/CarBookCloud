using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreatePricingCommand(PricingCreateDto Dto) : IRequest<PricingResultDto>;
    public record DeletePricingCommand(int PricingID) : IRequest<Unit>;
    public record UpdatePricingCommand(PricingUpdateDto Dto) : IRequest<PricingResultDto>;
}
