using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateAboutCommand(AboutCreateDto Dto) : IRequest<AboutResultDto>;
    public record DeleteAboutCommand(int AboutID) : IRequest<Unit>;
    public record UpdateAboutCommand(AboutUpdateDto Dto) : IRequest<AboutResultDto>;
}
