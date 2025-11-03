using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateCarCommand(CarCreateDto Dto) : IRequest<CarResultDto>;
    public record DeleteCarCommand(int CarID) : IRequest<Unit>;
    public record UpdateCarCommand(UpdateCarDto Dto) : IRequest<CarResultDto>;
}
