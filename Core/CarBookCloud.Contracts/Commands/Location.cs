using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateLocationCommand(LocationCreateDto Dto) : IRequest<LocationResultDto>;
    public record DeleteLocationCommand(int LocationID) : IRequest<Unit>;
    public record UpdateLocationCommand(LocationUpdateDto Dto) : IRequest<LocationResultDto>;
}
