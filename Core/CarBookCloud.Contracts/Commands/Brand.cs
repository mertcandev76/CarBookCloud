using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateBrandCommand(CreateBrandDto Dto) : IRequest<BrandResultDto>;
    public record DeleteBrandCommand(int BrandID) : IRequest<Unit>;
    public record UpdateBrandCommand(UpdateBrandDto Dto) : IRequest<BrandResultDto>;
}
