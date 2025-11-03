using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateCarDescriptionCommand(CarDescriptionCreateDto Dto) : IRequest<CarDescriptionResultDto>;
    public record DeleteCarDescriptionCommand(int CarDescriptionID) : IRequest<Unit>;
    public record UpdateCarDescriptionCommand(CarDescriptionUpdateDto Dto) : IRequest<CarDescriptionResultDto>;
}
