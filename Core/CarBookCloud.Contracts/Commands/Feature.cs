using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateFeatureCommand(FeatureCreateDto Dto) : IRequest<FeatureResultDto>;
    public record DeleteFeatureCommand(int FeatureID) : IRequest<Unit>;
    public record UpdateFeatureCommand(FeatureUpdateDto Dto) : IRequest<FeatureResultDto>;
}
