using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateContactCommand(ContactCreateDto Dto) : IRequest<ContactResultDto>;
    public record DeleteContactCommand(int ContactID) : IRequest<Unit>;
    public record UpdateContactCommand(ContactUpdateDto Dto) : IRequest<ContactResultDto>;
}
