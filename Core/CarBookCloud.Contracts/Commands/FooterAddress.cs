using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateFooterAddressCommand(FooterAddressCreateDto Dto) : IRequest<FooterAddressResultDto>;
    public record DeleteFooterAddressCommand(int FooterAddressID) : IRequest<Unit>;
    public record UpdateFooterAddressCommand(FooterAddressUpdateDto Dto) : IRequest<FooterAddressResultDto>;
}
