using CarBookCloud.Contracts.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookCloud.Contracts.Commands
{
    public record CreateBannerCommand(BannerCreateDto Dto) : IRequest<BannerResultDto>;
    public record DeleteBannerCommand(int BannerID) : IRequest<Unit>;
    public record UpdateBannerCommand(BannerUpdateDto Dto) : IRequest<BannerResultDto>;
}
