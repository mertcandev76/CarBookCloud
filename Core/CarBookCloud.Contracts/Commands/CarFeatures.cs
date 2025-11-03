using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateCarFeatureCommand(CarFeatureCreateDto Dto) : IRequest<CarFeatureResultDto>;
    public record DeleteCarFeatureCommand(int CarFeatureID) : IRequest<Unit>;
    public record UpdateCarFeatureCommand(CarFeatureUpdateDto Dto) : IRequest<CarFeatureResultDto>;
}
