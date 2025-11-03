using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateServiceCommand(ServiceCreateDto Dto) : IRequest<ServiceResultDto>;
    public record DeleteServiceCommand(int ServiceID) : IRequest<Unit>;
    public record UpdateServiceCommand(ServiceUpdateDto Dto) : IRequest<ServiceResultDto>;
}
